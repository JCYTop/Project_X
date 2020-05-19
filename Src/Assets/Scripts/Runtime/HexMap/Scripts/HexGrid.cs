using UnityEngine;
using UnityEngine.UI;

namespace Runtime.HexMap.Scripts
{
    public class HexGrid : MonoBehaviour
    {
        private HexCell[] cells;
        private int cellCountX;
        private int cellCountZ;
        private HexGridChunk[] chunks;
        public int chunkCountX = 4;
        public int chunkCountZ = 3;
        public Color defaultColor = Color.white;
        public HexCell cellPrefab;
        public Text cellLabelPrefab;
        public Texture2D noiseSource;
        public HexGridChunk chunkPrefab;

        private void Awake()
        {
            HexMetrics.noiseSource = noiseSource;
            cellCountX = chunkCountX * HexMetrics.chunkSizeX;
            cellCountZ = chunkCountZ * HexMetrics.chunkSizeZ;
            CreateChunks();
            CreateCells();
        }

        private void CreateChunks()
        {
            chunks = new HexGridChunk[chunkCountX * chunkCountZ];
            for (int z = 0, i = 0; z < chunkCountZ; z++)
            {
                for (int x = 0; x < chunkCountX; x++)
                {
                    var chunk = chunks[i++] = Instantiate(chunkPrefab);
                    chunk.transform.SetParent(transform);
                }
            }
        }

        private void CreateCells()
        {
            cells = new HexCell[cellCountZ * cellCountX];
            for (int z = 0, i = 0; z < cellCountZ; z++)
            {
                for (int x = 0; x < cellCountX; x++)
                {
                    CreateCell(x, z, i++);
                }
            }
        }

        private void OnEnable()
        {
            HexMetrics.noiseSource = noiseSource;
        }

        public HexCell GetCell(HexCoordinates coordinates)
        {
            var z = coordinates.Z;
            if (z < 0 || z >= cellCountZ)
            {
                return null;
            }

            var x = coordinates.X + z / 2;
            if (x < 0 || x >= cellCountX)
            {
                return null;
            }

            return cells[x + z * cellCountX];
        }

        public HexCell GetCell(Vector3 position)
        {
            position = transform.InverseTransformPoint(position);
            var coordinates = HexCoordinates.FromPosition(position);
            var index = coordinates.X + coordinates.Z * cellCountX + coordinates.Z / 2;
            return cells[index];
        }

        private void CreateCell(int x, int z, int i)
        {
            Vector3 position;
            position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
            position.y = 0f;
            position.z = z * (HexMetrics.outerRadius * 1.5f);
            var cell = cells[i] = Instantiate<HexCell>(cellPrefab);
            cell.transform.localPosition = position;
            cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
            cell.Color = defaultColor;
            if (x > 0)
            {
                cell.SetNeighbor(HexDirection.W, cells[i - 1]);
            }

            if (z > 0)
            {
                if ((z & 1) == 0)
                {
                    cell.SetNeighbor(HexDirection.SE, cells[i - cellCountX]);
                    if (x > 0)
                    {
                        cell.SetNeighbor(HexDirection.SW, cells[i - cellCountX - 1]);
                    }
                }
                else
                {
                    cell.SetNeighbor(HexDirection.SW, cells[i - cellCountX]);
                    if (x < cellCountX - 1)
                    {
                        cell.SetNeighbor(HexDirection.SE, cells[i - cellCountX + 1]);
                    }
                }
            }

            var label = Instantiate<Text>(cellLabelPrefab);
            label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
            label.text = cell.coordinates.ToStringOnSeparateLines();
            cell.uiRect = label.rectTransform;
            cell.Elevation = 0;
            AddCellToChunk(x, z, cell);
        }

        private void AddCellToChunk(int x, int z, HexCell cell)
        {
            var chunkX = x / HexMetrics.chunkSizeX;
            var chunkZ = z / HexMetrics.chunkSizeZ;
            var chunk = chunks[chunkX + chunkZ * chunkCountX];
            var localX = x - chunkX * HexMetrics.chunkSizeX;
            var localZ = z - chunkZ * HexMetrics.chunkSizeZ;
            chunk.AddCell(localX + localZ * HexMetrics.chunkSizeX, cell);
        }

        public void ShowUI(bool visible)
        {
            for (int i = 0; i < chunks.Length; i++)
            {
                chunks[i].ShowUI(visible);
            }
        }
    }
}
using UnityEngine;

namespace Runtime.HexMap.Scripts
{
    public class HexCell : MonoBehaviour
    {
        private int elevation = int.MinValue;
        private Color color;
        [SerializeField] private HexCell[] neighbors;
        public HexCoordinates coordinates;
        public RectTransform uiRect;
        public HexGridChunk chunk;

        public int Elevation
        {
            get { return elevation; }
            set
            {
                if (elevation == value)
                    return;
                elevation = value;
                var position = transform.localPosition;
                position.y = value * HexMetrics.elevationStep;
                position.y += (HexMetrics.SampleNoise(position).y * 2f - 1f) * HexMetrics.elevationPerturbStrength;
                transform.localPosition = position;
                var uiPosition = uiRect.localPosition;
                uiPosition.z = -position.y;
                uiRect.localPosition = uiPosition;
                Refresh();
            }
        }

        public Color Color
        {
            get { return color; }
            set
            {
                if (color == value)
                    return;
                color = value;
                Refresh();
            }
        }

        public Vector3 Position
        {
            get { return transform.localPosition; }
        }

        private void Refresh()
        {
            if (chunk)
            {
                chunk.Refresh();
                //刷新周边地块
                for (int i = 0; i < neighbors.Length; i++)
                {
                    HexCell neighbor = neighbors[i];
                    if (neighbor != null && neighbor.chunk != chunk)
                    {
                        neighbor.chunk.Refresh();
                    }
                }
            }
        }

        public HexCell GetNeighbor(HexDirection direction)
        {
            return neighbors[(int) direction];
        }

        public void SetNeighbor(HexDirection direction, HexCell cell)
        {
            neighbors[(int) direction] = cell;
            cell.neighbors[(int) direction.Opposite()] = this;
        }

        public HexEdgeType GetEdgeType(HexDirection direction)
        {
            return HexMetrics.GetEdgeType(elevation, neighbors[(int) direction].elevation);
        }

        public HexEdgeType GetEdgeType(HexCell otherCell)
        {
            return HexMetrics.GetEdgeType(elevation, otherCell.elevation);
        }
    }
}
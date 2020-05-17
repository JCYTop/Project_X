/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     HexGrid
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/22 22:55:41
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEngine;
using UnityEngine.UI;

namespace Runtime.HexMap
{
    public class HexGrid : MonoBehaviour
    {
        private HexMesh hexMesh;
        private HexCell[] cells;
        private Canvas gridCanvas;
        public int width = 6;
        public int height = 6;
        public HexCell cellPrefab;
        public Text cellLabelPrefab;
        public Color defaultColor = Color.white;
        public Color touchedColor = Color.magenta;
        public Texture2D noiseSource;

        private void Awake()
        {
            HexMetrics.noiseSource = noiseSource;
            gridCanvas = GetComponentInChildren<Canvas>();
            hexMesh = GetComponentInChildren<HexMesh>();
            cells = new HexCell[height * width];
            for (int z = 0, i = 0; z < height; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    CreateCell(x, z, i++);
                }
            }
        }

        private void OnEnable()
        {
            HexMetrics.noiseSource = noiseSource;
        }

        private void Start()
        {
            hexMesh.Triangulate(cells);
        }

        public HexCell GetCell(Vector3 position)
        {
            position = transform.InverseTransformPoint(position);
            var coordinates = HexCoordinates.FromPosition(position);
            var index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
            return cells[index];
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void Refresh()
        {
            hexMesh.Triangulate(cells);
        }

        public void TouchCell(Vector3 position, Color color)
        {
            position = transform.InverseTransformPoint(position);
            var coordinates = HexCoordinates.FromPosition(position);
            var index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
            var cell = cells[index];
            cell.color = color;
            hexMesh.Triangulate(cells);
            LogTool.Log($"Touched at {coordinates.ToString()}");
        }

        /// <summary>
        /// 创建单元
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <param name="i"></param>
        private void CreateCell(int x, int z, int i)
        {
            Vector3 position;
            position.x = (x + z * .5f - z / 2) * (HexMetrics.innerRadius * 2f);
            position.y = 0f;
            position.z = z * (HexMetrics.outerRadius * 1.5f);
            var cell = cells[i] = Instantiate<HexCell>(cellPrefab);
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
            cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
            cell.color = defaultColor;
            if (x > 0)
            {
                cell.SetNeighbor(HexDirection.W, cells[i - 1]);
            }

            if (z > 0)
            {
                if ((z & 1) == 0)
                {
                    cell.SetNeighbor(HexDirection.SE, cells[i - width]);
                    if (x > 0)
                    {
                        cell.SetNeighbor(HexDirection.SW, cells[i - width - 1]);
                    }
                }
                else
                {
                    cell.SetNeighbor(HexDirection.SW, cells[i - width]);
                    if (x < width - 1)
                    {
                        cell.SetNeighbor(HexDirection.SE, cells[i - width + 1]);
                    }
                }
            }

            var label = Instantiate<Text>(cellLabelPrefab);
            label.rectTransform.SetParent(gridCanvas.transform, false);
            label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
            label.text = cell.coordinates.ToStringOnSeparateLines();
            cell.uiRect = label.rectTransform;
            cell.Elevation = 0;
        }
    }

    /// <summary>
    /// 六边形指向
    /// </summary>
    public enum HexDirection
    {
        NE,
        E,
        SE,
        SW,
        W,
        NW
    }

    /// <summary>
    /// 六边形指向扩展方法
    /// </summary>
    public static class HexDirectionExtensions
    {
        /// <summary>
        /// 取反
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static HexDirection Opposite(this HexDirection direction)
        {
            return (int) direction < 3 ? (direction + 3) : (direction - 3);
        }

        public static HexDirection Previous(this HexDirection direction)
        {
            return direction == HexDirection.NE ? HexDirection.NW : (direction - 1);
        }

        public static HexDirection Next(this HexDirection direction)
        {
            return direction == HexDirection.NW ? HexDirection.NE : (direction + 1);
        }
    }
}
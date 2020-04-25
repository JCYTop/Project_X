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

        private void Awake()
        {
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

        private void Start()
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

            var label = Instantiate<Text>(cellLabelPrefab);
            label.rectTransform.SetParent(gridCanvas.transform, false);
            label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
            label.text = cell.coordinates.ToStringOnSeparateLines();
        }
    }

    public enum HexDirection
    {
        NE,
        E,
        SE,
        SW,
        W,
        NW
    }

    public static class HexDirectionExtensions
    {
        public static HexDirection Opposite(this HexDirection direction)
        {
            return (int) direction < 3 ? (direction + 3) : (direction - 3);
        }
    }
}
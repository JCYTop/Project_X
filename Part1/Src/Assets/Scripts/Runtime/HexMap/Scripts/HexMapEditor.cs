using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.HexMap.Scripts
{
    public class HexMapEditor : MonoBehaviour
    {
        private int activeElevation;
        private Color activeColor;
        private bool applyColor;
        private int brushSize;
        private bool applyElevation = true;
        public Color[] colors;
        public HexGrid hexGrid;

        public void SelectColor(int index)
        {
            applyColor = index >= 0;
            if (applyColor)
            {
                activeColor = colors[index];
            }
        }

        public void SetElevation(float elevation)
        {
            activeElevation = (int) elevation;
        }

        private void Awake()
        {
            SelectColor(0);
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                HandleInput();
            }
        }

        private void HandleInput()
        {
            var inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(inputRay, out var hit))
            {
                EditCells(hexGrid.GetCell(hit.point));
            }
        }

        private void EditCells(HexCell center)
        {
            var centerX = center.coordinates.X;
            var centerZ = center.coordinates.Z;
            for (int r = 0, z = centerZ - brushSize; z <= centerZ; z++, r++)
            {
                for (int x = centerX - r; x <= centerX + brushSize; x++)
                {
                    EditCell(hexGrid.GetCell(new HexCoordinates(x, z)));
                }
            }

            for (int r = 0, z = centerZ + brushSize; z > centerZ; z--, r++)
            {
                for (int x = centerX - brushSize; x <= centerX + r; x++)
                {
                    EditCell(hexGrid.GetCell(new HexCoordinates(x, z)));
                }
            }
        }

        private void EditCell(HexCell cell)
        {
            if (cell)
            {
                if (applyColor)
                {
                    cell.Color = activeColor;
                }

                if (applyElevation)
                {
                    cell.Elevation = activeElevation;
                }
            }
        }

        public void SetApplyElevation(bool toggle)
        {
            applyElevation = toggle;
        }

        public void SetBrushSize(float size)
        {
            brushSize = (int) size;
        }

        public void ShowUI(bool visible)
        {
            hexGrid.ShowUI(visible);
        }
    }
}
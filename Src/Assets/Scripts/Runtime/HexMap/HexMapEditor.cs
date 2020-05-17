/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     HexMapEditor
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/26 00:01:35
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.HexMap
{
    public class HexMapEditor : MonoBehaviour
    {
        private int activeElevation;
        private Color activeColor;
        public Color[] colors;
        public HexGrid hexGrid;

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
                EditCell(hexGrid.GetCell(hit.point));
            }
        }

        private void EditCell(HexCell cell)
        {
            cell.color = activeColor;
            cell.Elevation = activeElevation;
            hexGrid.Refresh();
        }

        public void SelectColor(int index)
        {
            activeColor = colors[index];
        }

        public void SetElevation(float elevation)
        {
            activeElevation = (int) elevation;
        }
    }
}
/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     HexGridChunk
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/05/18 22:32:26
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEngine;

namespace Runtime.HexMap.Scripts
{
    public class HexGridChunk : MonoBehaviour
    {
        private HexCell[] cells;
        private HexMesh hexMesh;
        private Canvas gridCanvas;

        private void Awake()
        {
            gridCanvas = GetComponentInChildren<Canvas>();
            hexMesh = GetComponentInChildren<HexMesh>();
            cells = new HexCell[HexMetrics.chunkSizeX * HexMetrics.chunkSizeZ];
            ShowUI(false);
        }

        private void LateUpdate()
        {
            hexMesh.Triangulate(cells);
            enabled = false;
        }

        public void Refresh()
        {
            enabled = true;
        }

        public void AddCell(int index, HexCell cell)
        {
            cells[index] = cell;
            cell.chunk = this;
            cell.transform.SetParent(transform, false);
            cell.uiRect.SetParent(gridCanvas.transform, false);
        }

        public void ShowUI(bool visible)
        {
            gridCanvas.gameObject.SetActive(visible);
        }
    }
}
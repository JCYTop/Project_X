/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     HexCell
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/22 22:50:13
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEngine;

namespace Runtime.HexMap
{
    public class HexCell : MonoBehaviour
    {
        private int elevation;
        [SerializeField] private HexCell[] neighbors;
        public HexCoordinates coordinates;
        public Color color;
        public RectTransform uiRect;

        /// <summary>
        /// 海拔设置
        /// </summary>
        public int Elevation
        {
            get { return elevation; }
            set
            {
                elevation = value;
                var position = transform.localPosition;
                position.y += (HexMetrics.SampleNoise(position).y * 2f - 1f) * HexMetrics.elevationPerturbStrength;
                transform.localPosition = position;
                var uiPosition = uiRect.localPosition;
//                uiPosition.z = elevation * -HexMetrics.elevationStep;
                uiPosition.z = -position.y;
                uiRect.localPosition = uiPosition;
            }
        }

        public Vector3 Position
        {
            get { return transform.localPosition; }
        }

        /// <summary>
        /// 获取邻近关系
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public HexCell GetNeighbor(HexDirection direction)
        {
            return neighbors[(int) direction];
        }

        /// <summary>
        /// 设置邻近关系
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="cell"></param>
        public void SetNeighbor(HexDirection direction, HexCell cell)
        {
            neighbors[(int) direction] = cell;
            cell.neighbors[(int) direction.Opposite()] = this;
        }

        /// <summary>
        /// 获取自身边界类型
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public HexEdgeType GetEdgeType(HexDirection direction)
        {
            return HexMetrics.GetEdgeType(elevation, neighbors[(int) direction].elevation);
        }

        /// <summary>
        /// 获取俩边界不同海拔之间的连接类型
        /// </summary>
        /// <param name="otherCell"></param>
        /// <returns></returns>
        public HexEdgeType GetEdgeType(HexCell otherCell)
        {
            return HexMetrics.GetEdgeType(elevation, otherCell.elevation);
        }
    }
}
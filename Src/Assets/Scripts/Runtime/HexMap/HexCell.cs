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
        [SerializeField] private HexCell[] neighbors;
        public HexCoordinates coordinates;
        public Color color;
        public HexCell GetNeighbor(HexDirection direction)
        {
            return neighbors[(int) direction];
        }

        public void SetNeighbor(HexDirection direction, HexCell cell)
        {
            neighbors[(int) direction] = cell;
            cell.neighbors[(int) direction.Opposite()] = this;
        }
    }
}
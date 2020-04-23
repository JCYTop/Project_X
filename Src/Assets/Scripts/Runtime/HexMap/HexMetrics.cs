/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     HexMetrics
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/22 22:25:17
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEngine;

namespace Runtime.HexMap
{
    /// <summary>
    /// TODO Step1 Hexagons
    /// </summary>
    public static class HexMetrics
    {
        /// <summary>
        /// 外切圆半径
        /// </summary>
        public const float outerRadius = 10f;

        /// <summary>
        /// 内切圆半径
        /// </summary>
        public const float innerRadius = outerRadius * 0.866025404f;

        /// <summary>
        /// 六边形每个边角坐标
        /// </summary>
        public static Vector3[] corners =
        {
            new Vector3(0f, 0f, outerRadius),
            new Vector3(innerRadius, 0f, 0.5f * outerRadius),
            new Vector3(innerRadius, 0f, -0.5f * outerRadius),
            new Vector3(0f, 0f, -outerRadius),
            new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
            new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
            new Vector3(0f, 0f, outerRadius)
        };
    }
}
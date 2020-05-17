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
        /// 实心颜色比例
        /// </summary>
        public const float solidFactor = 0.75f;

        /// <summary>
        /// 混合颜色比例
        /// </summary>
        public const float blendFactor = 1f - solidFactor;

        /// <summary>
        /// 高度步长
        /// </summary>
        public const float elevationStep = 5f;

        public const int terracesPerSlope = 2;
        public const int terraceSteps = terracesPerSlope * 2 + 1;
        public const float horizontalTerraceStepSize = 1f / terraceSteps;
        public const float verticalTerraceStepSize = 1f / (terracesPerSlope + 1);

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

        /// <summary>
        /// 噪声图
        /// </summary>
        public static Texture2D noiseSource;

        /// <summary>
        /// 单位扰动强度
        /// </summary>
        public const float cellPerturbStrength = 5f;

        /// <summary>
        /// nosie缩放比
        /// </summary>
        public const float noiseScale = 0.003f;

        /// <summary>
        /// 高度最大的噪音变化
        /// </summary>
        public const float elevationPerturbStrength = 1.5f;

        public static Vector3 GetFirstCorner(HexDirection direction)
        {
            return corners[(int) direction];
        }

        public static Vector3 GetSecondCorner(HexDirection direction)
        {
            return corners[(int) direction + 1];
        }

        public static Vector3 GetFirstSolidCorner(HexDirection direction)
        {
            return corners[(int) direction] * solidFactor;
        }

        public static Vector3 GetSecondSolidCorner(HexDirection direction)
        {
            return corners[(int) direction + 1] * solidFactor;
        }

        public static Vector3 GetBridge(HexDirection direction)
        {
            return (corners[(int) direction] + corners[(int) direction + 1]) * blendFactor;
        }

        public static Vector3 TerraceLerp(Vector3 a, Vector3 b, int step)
        {
            var h = step * horizontalTerraceStepSize;
            a.x += (b.x - a.x) * h;
            a.z += (b.z - a.z) * h;
            var v = ((step + 1) / 2) * verticalTerraceStepSize;
            a.y += (b.y - a.y) * v;
            return a;
        }

        public static Color TerraceLerp(Color a, Color b, int step)
        {
            float h = step * HexMetrics.horizontalTerraceStepSize;
            return Color.Lerp(a, b, h);
        }

        public static HexEdgeType GetEdgeType(int elevation1, int elevation2)
        {
            if (elevation1 == elevation2)
            {
                return HexEdgeType.Flat;
            }

            var delta = elevation2 - elevation1;
            if (delta == 1 || delta == -1)
            {
                return HexEdgeType.Slope;
            }

            return HexEdgeType.Cliff;
        }

        /// <summary>
        /// 简单噪声图
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Vector4 SampleNoise(Vector3 position)
        {
            return noiseSource.GetPixelBilinear(position.x * noiseScale, position.z * noiseScale);
        }
    }
}
/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     BezierUtil
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/28 18:07:46
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;

public static class BezierUtil
{
    private static int segmentNum = 15;

    public static int SegmentNum
    {
        get { return segmentNum; }
        set
        {
            if (value > 20)
                segmentNum = value;
        }
    }

    public static Vector3[] DrawCurve(Vector3 cardPosition, Vector3 mousePositon)
    {
        var point = new Vector3[segmentNum];
        var position1 = new Vector3();
        var position2 = new Vector3();
        position1.y = mousePositon.y * .2f;
        position1.x = cardPosition.x - (mousePositon.x - cardPosition.x) / 2f;
        position2.x = mousePositon.x * .35f;
        position2.y = mousePositon.y * 1.3f;
        for (int i = 1; i <= segmentNum; i++)
        {
            float t = i / (float) segmentNum;
            point[i - 1] = CalculateBezierPoint(t, cardPosition, position1, position2, mousePositon);
        }

        return point;
    }

    /// <summary>
    /// 俩点贝塞尔,从起点到终点
    /// </summary>
    /// <param name="t"></param>
    /// <param name="p0"></param>
    /// <param name="p1"></param>
    /// <returns></returns>
    private static Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1)
    {
        var u = 1 - t;
        var p = u * p0 + t * p1;
        return p;
    }

    /// <summary>
    /// 三点贝塞尔,从起点到终点
    /// </summary>
    /// <param name="t"></param>
    /// <param name="p0"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    private static Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        var u = 1 - t;
        var tt = t * t;
        var uu = u * u;
        var p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }

    /// <summary>
    /// 四点贝塞尔,从起点到终点
    /// </summary>
    /// <param name="t"></param>
    /// <param name="p0"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns></returns>
    private static Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        var u = 1 - t;
        var uu = u * u;
        var uuu = u * u * u;
        var tt = t * t;
        var ttt = t * t * t;
        var p = uuu * p0;
        p += 3 * p1 * t * uu;
        p += 3 * p2 * tt * u;
        p += p3 * ttt;
        return p;
    }

    public static Vector3[] GetBeizerList(int segmentNum, params Vector3[] points)
    {
        var path = new Vector3[segmentNum];
        for (int i = 1; i <= segmentNum; i++)
        {
            var t = i / (float) segmentNum;
            var pixel = new Vector3();
            switch (points.Length)
            {
                case 2:
                    pixel = CalculateBezierPoint(t, points[0], points[1]);
                    break;
                case 3:
                    pixel = CalculateBezierPoint(t, points[0], points[1], points[2]);
                    break;
                case 4:
                    pixel = CalculateBezierPoint(t, points[0], points[1], points[2], points[3]);
                    break;
            }

            path[i - 1] = pixel;
            LogUtil.Log(path[i - 1].ToString(), LogType.NormalLog);
        }

        return path;
    }
}

public enum BezierStyle
{
    Square = 0,
    Cubic,
    FourthPower,
}
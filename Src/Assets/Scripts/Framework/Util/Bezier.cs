using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier
{
    enum BezierStyle
    {
        Square = 0,
        Cubic,
        FourthPower,
    }

    private static Bezier _instance;
    private int segmentNum = 15;

    public static Bezier Instance()
    {
        if (_instance == null)
            _instance = new Bezier();
        return _instance;
    }

    public int SegmentNum
    {
        get { return segmentNum; }
        set
        {
            if (value > 20)
                segmentNum = value;
        }
    }

    public Vector3[] DrawCurve(Vector3 cardPosition, Vector3 mousePositon)
    {
        Vector3[] point = new Vector3[segmentNum];
        Vector3 position1 = new Vector3();
        Vector3 position2 = new Vector3();
        position1.y = mousePositon.y * .2f;
        position1.x = cardPosition.x - (mousePositon.x - cardPosition.x) / 2f;
        position2.x = mousePositon.x * .35f;
        position2.y = mousePositon.y * 1.3f;
        for (int i = 1; i <= segmentNum; i++)
        {
            float t = i / (float)segmentNum;
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
    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1)
    {
        float u = 1 - t;
        Vector3 p = u * p0 + t * p1;
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
    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
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
    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float uu = u * u;
        float uuu = u * u * u;
        float tt = t * t;
        float ttt = t * t * t;
        Vector3 p = uuu * p0;
        p += 3 * p1 * t * uu;
        p += 3 * p2 * tt * u;
        p += p3 * ttt;
        return p;
    }

    public Vector3[] GetBeizerList(int segmentNum, params Vector3[] points)
    {
        Vector3[] path = new Vector3[segmentNum];
        for (int i = 1; i <= segmentNum; i++)
        {
            float t = i / (float)segmentNum;
            Vector3 pixel = new Vector3();
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
            Debug.Log(path[i - 1]);
        }
        return path;
    }
}

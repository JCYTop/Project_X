using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIExtension
{
    /// <summary>
    /// 鼠标点击位置准换成UGUI坐标
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="input"></param>
    /// <param name="camera"></param>
    public static Vector2 ScreenPointToLocalPointInRectangle(this Canvas canvas, Vector3 input, Camera camera)
    {
        Vector3 ScreenPos = camera.WorldToScreenPoint(input);
        Vector2 pos = new Vector2();
        bool isOk =  RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), ScreenPos, canvas.GetComponent<Canvas>().worldCamera, out pos);
        if (!isOk)
            return default(Vector2);
        return pos;
    }

    /// <summary>
    /// 鼠标点击位置准换成世界坐标
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="input"></param>
    /// <param name="camera"></param>
    public static Vector3 ScreenPointToWorldPointInRectangle(this Canvas canvas, Vector3 input, Camera camera)
    {
        Vector3 ScreenPos = camera.WorldToScreenPoint(input);
        Vector3 pos = new Vector3();
        bool isOk = RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), ScreenPos, canvas.GetComponent<Canvas>().worldCamera, out pos);
        if (!isOk)
            return default(Vector2);
        return pos;
    }


}
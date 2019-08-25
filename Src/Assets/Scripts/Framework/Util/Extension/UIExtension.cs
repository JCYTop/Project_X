using UnityEngine;

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
        var ScreenPos = camera.WorldToScreenPoint(input);
        var pos = new Vector2();
        var isOk = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), ScreenPos,
            canvas.GetComponent<Canvas>().worldCamera, out pos);
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
        var ScreenPos = camera.WorldToScreenPoint(input);
        var pos = new Vector3();
        var isOk = RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), ScreenPos,
            canvas.GetComponent<Canvas>().worldCamera, out pos);
        if (!isOk)
            return default(Vector2);
        return pos;
    }
}
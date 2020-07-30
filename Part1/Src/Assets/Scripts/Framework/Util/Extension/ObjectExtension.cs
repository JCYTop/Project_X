using System;
using Object = UnityEngine.Object;

public static class ObjectExtension
{
    #region  Instantiate

    public static T Instantiate<T>(this T selfObj) where T : Object
    {
        return Object.Instantiate(selfObj);
    }

    #endregion

    #region  Instantiate_Name

    public static T InstantiateName<T>(this T selfObj, string name) where T : Object
    {
        selfObj.name = name;
        return selfObj;
    }

    #endregion

    #region  Destroy Self

    public static void DestroySelf<T>(this T selfObj) where T : Object
    {
        Object.Destroy(selfObj);
    }

    public static T DestroySelfGracefully<T>(this T selfObj) where T : Object
    {
        if (selfObj)
        {
            Object.Destroy(selfObj);
        }

        return selfObj;
    }

    #endregion

    #region  Destroy Self AfterDelay 

    public static T DestroySelfAfterDelay<T>(this T selfObj, float afterDelay) where T : Object
    {
        Object.Destroy(selfObj, afterDelay);
        return selfObj;
    }

    public static T DestroySelfAfterDelayGracefully<T>(this T selfObj, float delay) where T : Object
    {
        if (selfObj)
        {
            Object.Destroy(selfObj, delay);
        }

        return selfObj;
    }

    #endregion

    #region  DontDestroyOnLoad

    public static T DontDestroyOnLoad<T>(this T selfObj) where T : Object
    {
        Object.DontDestroyOnLoad(selfObj);
        return selfObj;
    }

    #endregion

    /// <summary>
    /// 转换成指定类型的
    /// </summary>
    /// <param name="element"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T CastType<T>(this object element)
    {
        try
        {
            return (T) element;
        }
        catch (Exception e)
        {
            LogTool.LogException(e);
            throw;
        }
    }
}
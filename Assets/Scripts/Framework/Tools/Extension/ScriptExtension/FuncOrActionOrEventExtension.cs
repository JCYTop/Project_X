using System;

public static class FuncOrActionOrEventExtension
{
    #region Func Extension
    /// <summary>
    /// 通知所有Func
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selfFunc"></param>
    /// <returns></returns>
    public static T InvokeGracefully<T>(this Func<T> selfFunc)
    {
        return null != selfFunc ? selfFunc() : default(T);
    }
    #endregion

    #region Action
    /// <summary>
    /// 通知所有Action
    /// </summary>
    /// <param name="selfAction"></param>
    /// <returns> call succeed</returns>
    public static bool InvokeGracefully(this System.Action selfAction)
    {
        if (null != selfAction)
        {
            selfAction();
            return true;
        }
        return false;
    }

    /// <summary>
    /// 通知所有Action
    /// </summary>
    /// <param name="selfAction"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool InvokeGracefully<T>(this Action<T> selfAction, T t)
    {
        if (null != selfAction)
        {
            selfAction(t);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 通知所有Action
    /// </summary>
    /// <param name="selfAction"></param>
    /// <returns> call succeed</returns>
    public static bool InvokeGracefully<T, K>(this Action<T, K> selfAction, T t, K k)
    {
        if (null != selfAction)
        {
            selfAction(t, k);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 通知所有delegate
    /// </summary>
    /// <param name="selfAction"></param>
    /// <returns> call suceed </returns>
    public static bool InvokeGracefully(this Delegate selfAction, params object[] args)
    {
        if (null != selfAction)
        {
            selfAction.DynamicInvoke(args);
            return true;
        }
        return false;
    }
    #endregion
}
using UnityEngine;

public static class EntityUtil
{
    /// <summary>
    /// 实例化物体
    /// </summary>
    /// <param name="go"></param>
    /// <param name="IsDotDestory"></param>
    /// <returns></returns>
    public static GameObject InstantiateGo(GameObject go, bool IsDotDestory = false)
    {
        var tmp = Object.Instantiate(go);
        if (IsDotDestory)
            Object.DontDestroyOnLoad(tmp);
        return tmp;
    }

    /// <summary>
    /// 得到或者添加组件
    /// </summary>
    /// <param name="gameObject"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
    }
}
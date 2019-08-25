using UnityEngine;

public static class EntityUtil
{
    /// <summary>
    /// 创建一个GO
    /// </summary>
    /// <param name="name"></param>
    /// <param name="IsDestroy"></param>
    /// <returns></returns>
    public static GameObject CreateGameobject(string name, bool IsDestroy = true)
    {
        return CreateGameobject(name, Vector3.one, IsDestroy);
    }

    public static GameObject CreateGameobject<T>(string name, bool IsDestroy = true) where T : Component
    {
        return CreateGameobject<T>(name, Vector3.one, IsDestroy);
    }

    /// <summary>
    /// 创建一个GO
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pos"></param>
    /// <param name="IsDestroy"></param>
    /// <returns></returns>
    public static GameObject CreateGameobject(string name, Vector3 pos, bool IsDestroy)
    {
        var gameObject = new GameObject(name);
        gameObject.transform.position = pos;
        if (!IsDestroy)
        {
            Object.DontDestroyOnLoad(gameObject);
        }

        return gameObject;
    }

    public static GameObject CreateGameobject<T>(string name, Vector3 pos, bool IsDestroy) where T : Component
    {
        var gameObject = new GameObject(name);
        gameObject.transform.position = pos;
        if (!IsDestroy)
        {
            Object.DontDestroyOnLoad(gameObject);
        }

        var type = gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        return gameObject;
    }

    /// <summary>
    /// 删除物体
    /// </summary>
    /// <param name="go"></param>
    public static void DestroyGO(GameObject go)
    {
        Object.Destroy(go);
    }

    /// <summary>
    /// 实例化物体
    /// </summary>
    /// <param name="go"></param>
    /// <param name="IsDotDestory"></param>
    /// <returns></returns>
    public static GameObject InstantiateGo(GameObject go, bool IsDotDestory = false)
    {
        var _go = Object.Instantiate(go);
        if (IsDotDestory)
            Object.DontDestroyOnLoad(_go);
        return _go;
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

    /// <summary>
    /// 计算物体之间的距离
    /// </summary>
    /// <param name="originalPos"></param>
    /// <param name="goalPos"></param>
    /// <returns></returns>
    public static float CalculateDistance(Vector3 originalPos, Vector3 goalPos)
    {
        //计算总距离
        var totalOffset = goalPos - originalPos;
        totalOffset.Scale(new Vector3(1, 0, 1));
        return totalOffset.magnitude;
    }
}
using UnityEngine;

public class GOCommonUtil
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
}
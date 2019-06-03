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

    public static void DestroyGO(GameObject go)
    {
        Object.Destroy(go);
    }
}
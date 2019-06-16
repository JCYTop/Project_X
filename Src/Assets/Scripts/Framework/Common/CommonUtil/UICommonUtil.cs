using System.Collections.Generic;
using UnityEngine;

public class UICommonUtil
{
    /// <summary>
    /// 清除父节点下的所有子物体
    /// </summary>
    /// <param name="parent">父节点</param>
    /// <returns>返回清除物体的组合</returns>
    public static GameObject[] CleanAllChild(GameObject parent)
    {
        GameObject[] tmp = new GameObject[parent.transform.childCount];
        for (int i = parent.transform.childCount; i > 0; i--)
        {
            tmp[i - 1] = parent.transform.GetChild(i - 1).gameObject;
            Object.Destroy(parent.transform.GetChild(i - 1));
        }

        return tmp;
    }

    /// <summary>
    /// 通过子节点找到父节点删除其底下所有的子物体
    /// </summary>
    /// <param name="ID">全局唯一ID</param>
    /// <returns>返回清除物体的组合</returns>
    public static GameObject[] CleanAllChild(int ID)
    {
        return CleanAllChild(ScenesMgr.GetGOInfo(ID).gameObject);
    }

    /// <summary>
    /// 设置孩子的父物体
    /// </summary>
    /// <param name="child"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static void SetParent(GameObject child, GameObject parent)
    {
        child.transform.SetParent(parent.transform);
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
    }

    #region 删除物体

    public static void DestroyGO(GameObject go)
    {
        Object.Destroy(go);
    }

    public static void DestroyGO<T>(List<T> list) where T : MonoBehaviour
    {
        foreach (var unit in list)
        {
            DestroyGO(unit.gameObject);
        }
    }

    #endregion
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIUtil
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
    /// 清理父物体下的所有子物体
    /// </summary>
    /// <param name="go"></param>
    /// <param name="callback"></param>
    public static void CleanAllChild(GameObject parent, UnityAction callback = null)
    {
        for (int i = parent.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(parent.transform.GetChild(i).gameObject);
        }

        if (callback != null) callback();
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

    /// <summary>
    /// 在一个父物体下创建一个子物体
    /// </summary>
    /// <param name="child">子物体</param>
    /// <param name="parent">父物体</param>
    /// <param name="count">创建次数，默认为0</param>
    public static GameObject CreateChildGameObject(GameObject child, GameObject parent)
    {
        var tmpGO = Object.Instantiate(child);
        tmpGO.transform.SetParent(parent.transform);
        tmpGO.transform.localPosition = Vector3.zero;
        tmpGO.transform.localScale = Vector3.one;
        tmpGO.SetActive(true);
        return tmpGO;
    }

    /// <summary>
    /// 在一个父物体下创建一个子物体
    /// </summary>
    /// <param name="child">子物体</param>
    /// <param name="parent">父物体</param>
    /// <param name="count">创建次数，默认为0</param>
    public static GameObject[] CreateChildGameObject(GameObject child, GameObject parent, int count = 1)
    {
        GameObject[] tmp = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            var tmpGO = Object.Instantiate(child);
            tmpGO.transform.SetParent(parent.transform);
            tmpGO.transform.localPosition = Vector3.zero;
            tmpGO.transform.localScale = Vector3.one;
            tmpGO.SetActive(true);
            tmp[i] = tmpGO;
        }

        return tmp;
    }

    /// <summary>
    /// 在一个父物体下创建一个子物体
    /// </summary>
    /// <param name="child">子物体</param>
    /// <param name="parent">父物体</param>
    /// <param name="count">创建次数，默认为0</param>
    public static GameObject[] CreateChildGameObject(GameObject child, GameObject parent, Vector3 scale, int count = 1)
    {
        GameObject[] tmp = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            var tmpGO = Object.Instantiate(child);
            tmpGO.transform.SetParent(parent.transform);
            tmpGO.transform.localPosition = Vector3.zero;
            tmpGO.transform.localScale = scale;
            tmpGO.SetActive(true);
            tmp[i] = tmpGO;
        }

        return tmp;
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

    /// <summary>
    /// 计算UI之间的距离
    /// </summary>
    /// <param name="originalPos"></param>
    /// <param name="goalPos"></param>
    /// <returns></returns>
    public static float CalculateUIDistance(Vector3 originalPos, Vector3 goalPos)
    {
        //计算总距离
        var totalOffset = goalPos - originalPos;
        totalOffset.Scale(new Vector3(1, 1, 0));
        return totalOffset.magnitude;
    }
}
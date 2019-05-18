using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICommonUtil : MonoSingleton<UICommonUtil>
{
    /// <summary>
    /// 清除父节点下的所有子物体
    /// </summary>
    /// <param name="parent">父节点</param>
    /// <returns>返回清除物体的组合</returns>
    public GameObject[] CleanAllChild(GameObject parent)
    {
        GameObject[] tmp = new GameObject[parent.transform.childCount];
        for (int i = parent.transform.childCount; i > 0; i--)
        {
            tmp[i - 1] = parent.transform.GetChild(i - 1).gameObject;
            Destroy(parent.transform.GetChild(i - 1));
        }

        return tmp;
    }

    /// <summary>
    /// 通过子节点找到父节点删除其底下所有的子物体
    /// </summary>
    /// <param name="ID">全局唯一ID</param>
    /// <returns>返回清除物体的组合</returns>
    public GameObject[] CleanAllChild(long ID)
    {
        return CleanAllChild(GameObjectMgr.GetGOInfo(ID).gameObject);
    }
}
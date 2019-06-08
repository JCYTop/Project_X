using System;
using UnityEngine;

public class GM : MonoBehaviour
{
    private bool isShow = false;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            isShow = !isShow;
            //TODO 同一个按键实现同时开关
            //AssetsManager.Instance().GetUIPrefabAsync("Common/GMPlane", (prefab) =>
            //{
            //    if (prefab != null)
            //    {
            //        Global.InstantiateGo(prefab, true);
            //        //TODO 添加类似于小森生活的UIBase
            //    }
            //    else
            //    {
            //    }
            //});
        }
    }
}
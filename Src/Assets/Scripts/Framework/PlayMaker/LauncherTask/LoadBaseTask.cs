//=====================================================
// - FileName:      LoadBaseData.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:46
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using Framework.Assets;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GameLanucherTask")]
public class LoadBaseTask : GameLanucherTask
{
    private List<string> resources = new List<string>();

    protected override void InitTask()
    {
        resources.Add("ExcelDataMgr");
        resources.Add("UIRoot");
    }

    protected override IEnumerator Task()
    {
        LogUtil.Log(string.Format(TaskName.Value), LogType.TaskLog);
        for (int i = 0; i < resources.Count; i++)
        {
            AssetsManager.Instance().GetPrefabAsync(resources[i], (prefab) =>
            {
                if (prefab != null)
                {
                    EntityUtil.InstantiateGo(prefab, true);
                }
            });
            yield return new WaitForFixedUpdate();
        }

        IsFinish = true;
    }
}
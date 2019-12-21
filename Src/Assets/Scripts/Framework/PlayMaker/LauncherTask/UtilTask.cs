//=====================================================
// - FileName:      LoadScenceTask.cs
// - Created:       @JCY
// - CreateTime:    2019/08/22 22:56:57
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GameLanucherTask")]
public class UtilTask : GameLanucherTask
{
    private List<string> resources = new List<string>();

    protected override void InitTask()
    {
        resources.Add("LangSetting");
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
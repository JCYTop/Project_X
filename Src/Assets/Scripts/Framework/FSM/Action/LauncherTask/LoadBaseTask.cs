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
using HutongGames.PlayMaker;
using UnityEngine;
using UnityEngine.AddressableAssets;

[ActionCategory("GameLanucherTask.LoadBaseTask")]
public class LoadBaseTask : GameLanucherTask
{
    private AssetLabelReference label = new AssetLabelReference();
    public string LabelName;

    protected override void InitTask()
    {
        label.labelString = LabelName;
    }

    protected override IEnumerator Task()
    {
        LogTool.Log($"{TaskName.Value}", LogEnum.TaskLog);
        yield return new WaitForFixedUpdate();
        AddressableMgr.LoadAssetsAsync<GameObject>(label, (go) => { EntityUtil.InstantiateGo(go, true); }, (completed) =>
        {
            completed.Completed += handle =>
            {
                LogTool.Log($"本次资源加载任务结束", LogEnum.TaskLog);
                IsFinish = true;
            };
        });
    }
}
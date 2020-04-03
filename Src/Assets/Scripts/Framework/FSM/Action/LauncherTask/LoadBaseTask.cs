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
using UnityEngine.ResourceManagement.AsyncOperations;

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
        AddressableAsyncAdapter.LoadAssetsAsync<GameObject>(label, (go) =>
        {
            LogTool.Log($"{go.name}");
            EntityUtil.InstantiateGo(go, true);
        }, (completed) =>
        {
            if (completed.Status == AsyncOperationStatus.Succeeded)
            {
                LogTool.Log($"资源加载完成", LogEnum.TaskLog);
                IsFinish = true;
            }
        });
    }
}
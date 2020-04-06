//=====================================================
// - FileName:      PreloadingTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:33:49
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using Framework.Singleton;
using HutongGames.PlayMaker;
using UnityEngine;
using UnityEngine.AddressableAssets;

[ActionCategory("GameLanucherTask.PreloadingTask")]
public class PreloadingTask : GameLanucherTask
{
    private AssetLabelReference label = new AssetLabelReference();

    protected override IEnumerator Task()
    {
        yield return new WaitForFixedUpdate();
        LogTool.Log($"{TaskName.Value}", LogEnum.TaskLog);
        label.labelString = "PreLoad";
        AddressableAsync.InitializeAsync(() =>
        {
            AddressableAsync.LoadAssetsAsync<object>(label, null, (completed) =>
            {
                LogTool.Log($"资源预加载完成", LogEnum.TaskLog);
                IsFinish = true;
            });
        });
    }
}
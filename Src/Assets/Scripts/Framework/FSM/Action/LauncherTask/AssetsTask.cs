//=====================================================
// - FileName:      AssetsTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:00
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using Framework.Assets;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GameLanucherTask")]
public class AssetsTask : GameLanucherTask
{
    protected override IEnumerator Task()
    {
        LogTool.Log(string.Format(TaskName.Value), LogEnum.TaskLog);
        yield return new WaitForFixedUpdate();
        AssetsManager.Instance();
        AssetBundleManager.Instance();
        AssetBundleLoader.Instance();
        IsFinish = true;
    }
}
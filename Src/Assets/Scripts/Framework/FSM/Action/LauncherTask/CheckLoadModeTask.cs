//=====================================================
// - FileName:      CheckLoadModeTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:32:14
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GameLanucherTask.CheckLoadModeTask")]
public class CheckLoadModeTask : GameLanucherTask
{
    protected override IEnumerator Task()
    {
        LogTool.Log($"{TaskName.Value}", LogEnum.TaskLog);
        yield return new WaitForFixedUpdate();
        IsFinish = true;
    }
}
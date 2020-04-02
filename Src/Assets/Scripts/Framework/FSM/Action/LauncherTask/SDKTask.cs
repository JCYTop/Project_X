//=====================================================
// - FileName:      SDKTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:32:48
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================


using System.Collections;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GameLanucherTask.SDKTask")]
public class SDKTask : GameLanucherTask
{
    protected override IEnumerator Task()
    {
        LogTool.Log($"{TaskName.Value}", LogEnum.TaskLog);
        yield return new WaitForFixedUpdate();
        IsFinish = true;
    }
}
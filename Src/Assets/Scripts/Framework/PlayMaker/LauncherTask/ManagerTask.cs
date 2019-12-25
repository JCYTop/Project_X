//=====================================================
// - FileName:      ManagerTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:17
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GameLanucherTask")]
public class ManagerTask : GameLanucherTask
{
    protected override IEnumerator Task()
    {
        LogUtil.Log(string.Format(TaskName.Value), LogType.TaskLog);
        yield return new WaitForFixedUpdate();
#if Dev
        EntityUtil.CreateGameobject<GM>("GM", false);
#endif
        EntityUtil.CreateGameobject<GlobalEvent>("GlobalEvent", false);
        IsFinish = true;
    }
}
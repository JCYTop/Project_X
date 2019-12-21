/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GameLanucherTask
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.2.1f1
 *CreateTime:   2019/12/21 23:28:53
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections;
using HutongGames.PlayMaker;

[ActionCategory("GameLanucherTask")]
public abstract class GameLanucherTask : FsmStateAction
{
    public FsmString TaskName;
    public FsmEvent FinishTask;
    public bool IsFinish { set; get; } = false;

    public override void OnEnter()
    {
        base.OnEnter();
        InitTask();
        CoroutineMgr.Instance().StartUpCoroutine(Task());
    }

    protected virtual void InitTask()
    {
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (IsFinish)
        {
            Fsm.Event(FinishTask);
        }
    }

    protected abstract IEnumerator Task();
}
/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AwakeState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 19:44:49
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GlobalState")]
public class AwakeState : GlobalState
{
    private (GameObject, GameLanucher ) tuple;
    public FsmEvent FsmNextEvent;

    public override void OnEnter()
    {
        base.OnEnter();
        LogUtil.Log(string.Format("AwakeState"), LogType.State);
        tuple = EntityUtil.CreateGameobject<GameLanucher>("GameLanucher");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (tuple.Item2.IsFinish)
        {
            Fsm.Event(FsmNextEvent);
        }
    }
}
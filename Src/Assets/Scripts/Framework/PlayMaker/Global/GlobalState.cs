/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AwakeGame
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 19:45:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using HutongGames.PlayMaker;

public abstract class GlobalState : FsmStateAction
{
    public bool EveryFrame;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Reset()
    {
        base.Reset();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (!EveryFrame)
        {
            Finish();
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnGUI()
    {
        base.OnGUI();
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
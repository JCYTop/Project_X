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

using UnityEngine;

public class AwakeState : FSMState
{
    private GameObject go;

    public AwakeState(string name) : base(name)
    {
    }

    public AwakeState()
    {
        Name = typeof(AwakeState).Name;
    }

    public override void InitTranslation()
    {
        translation.Add(new FSMTranslation(() => { return GlobalMediator.TaskIsFinish; }, typeof(StartState).Name));
    }

    public override void OnEnter()
    {
        LogUtil.Log(string.Format("AwakeState"), LogType.State);
        go = EntityUtil.CreateGameobject("GameLanucher");
        go.AddComponent<GameLanucher>();
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        Object.Destroy(go);
    }
}
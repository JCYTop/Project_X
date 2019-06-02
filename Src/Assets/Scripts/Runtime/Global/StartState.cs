/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     StartState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 19:52:41
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

public class StartState : FSMState
{
    public StartState(string name) : base(name)
    {
    }

    public StartState()
    {
        Name = typeof(StartState).Name;
    }

    public override void InitTranslation()
    {
    }

    public override void OnEnter()
    {
        LogUtil.Log(string.Format("StartState"));
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}
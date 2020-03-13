/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     DefaultActionHandler
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/13 14:51:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace Framework.GOAP
{
    public class DefaultActionHandler : ActionHandler
    {
        public override ActionExcuteState ExcuteState { get; }

        public override void AddFinishCallBack(Action onFinishAction)
        {
            this.onFinishAction = onFinishAction;
        }

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
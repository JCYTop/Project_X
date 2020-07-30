/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     WalkActionHandler
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
    public class WalkActionHandler : ActionHandler
    {
        public override void AddFinishCallBack(Action onFinishAction)
        {
            this.onFinishAction = onFinishAction;
        }

        public override void Enter(IContext context, Action callback)
        {
            LogTool.Log($"进入WalkActionHandler通知");
            base.Enter(context, callback);
        }

        public override void Execute(IContext context, Action callback)
        {
            base.Execute(context, callback);
            LogTool.Log($"进入ExecuteWalkActionHandler通知");

        }

        public override void Exit(IContext context, Action callback)
        {
            base.Exit(context, callback);
            LogTool.Log($"进入ExitWalkActionHandler通知");
        }
    }
}
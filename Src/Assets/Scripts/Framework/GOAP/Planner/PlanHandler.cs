/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     PlanHandler
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/17 22:56:34
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace Framework.GOAP
{
    public abstract class PlanHandler<TAction> : IPlanHandler<TAction>
    {
        public bool IsComplete { get; }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void AddCompleteCallBack(Action onComplete)
        {
            throw new NotImplementedException();
        }

        public void StartPlan()
        {
            throw new NotImplementedException();
        }

        public void NextAction()
        {
            throw new NotImplementedException();
        }

        public void Interruptible()
        {
            throw new NotImplementedException();
        }

        public IActionHandler<TAction> GetCurrentHandler()
        {
            throw new NotImplementedException();
        }
    }
}
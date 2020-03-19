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
    public abstract class PlanHandler<TAction, TGoal> : IPlanHandler<TAction, TGoal>
    {
        private Action onComplete;
        private IActionHandler<TAction> currentActionHandler;
        protected IPlanner<TAction, TGoal> planner;

        public IPlanner<TAction, TGoal> Planner
        {
            set
            {
                if (value != null) planner = value;
            }
            get { return planner; }
        }

        public bool IsComplete
        {
            get
            {
                //TODO 是否进行打断处理
                return default;
            }
        }

        public PlanHandler(IPlanner<TAction, TGoal> planner)
        {
            this.planner = planner;
        }

        public void HandlerAction()
        {
            throw new NotImplementedException();
        }

        public void Interruptible()
        {
            throw new NotImplementedException();
        }

        public IActionHandler<TAction> GetCurrentHandler()
        {
            return currentActionHandler;
        }

        public void AddCompleteCallBack(Action onComplete)
        {
            this.onComplete = onComplete;
        }
    }
}
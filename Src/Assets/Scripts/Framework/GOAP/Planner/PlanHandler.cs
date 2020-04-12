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
using System.Collections.Generic;

namespace Framework.GOAP
{
    public abstract class PlanHandler<TAction, TGoal> : IPlanHandler<TAction, TGoal>
    {
        private Action onComplete;
        private IActionHandler<TAction> currentActionHandler;
        private bool isInterruptible;
        protected IPlanner<TAction, TGoal> planner;
        public LinkedList<IActionHandler<TAction>> CurrActionHandlers { get; set; }
        public IGoal<TGoal> CurrGoal { get; set; }

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
                if (isInterruptible)
                {
                    var handle = GetCurrentHandler();
                    //还需要判断当前执行的动作是否可以被打断
                    //大部分动作是可以被打断的
                    if (handle.Action.IsInterruptiblePlan)
                        return true;
                    else
                        return false;
                }

                if (CurrActionHandlers == null || CurrActionHandlers.Count <= 0)
                {
                    return true;
                }

                if (currentActionHandler == null)
                {
                    return CurrActionHandlers.Count <= 0;
                }
                else
                {
                    return currentActionHandler.ExcuteState == ActionExcuteState.Exit && CurrActionHandlers.Count <= 0;
                }
            }
        }

        public PlanHandler(IPlanner<TAction, TGoal> planner)
        {
            this.planner = planner;
        }

        public IActionHandler<TAction> HandlerAction()
        {
            if (IsComplete)
            {
                onComplete();
                return null;
            }
            else
            {
                currentActionHandler = CurrActionHandlers.First.Value;
                CurrActionHandlers.RemoveFirst();
                LogTool.Log($"----当前要进行 执行的动作 ::: {currentActionHandler.Action.Label}");
            }

            return currentActionHandler;
        }

        public void Interruptible()
        {
            isInterruptible = true;
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
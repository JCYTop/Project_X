/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 22:11:30
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    public abstract class GoalBase<TGoal> : IGoal<TGoal>
    {
        public abstract TGoal Label { get; }
        private Action<IGoal<TGoal>> _onActivate;
        private Action<IGoal<TGoal>> _onInActivate;

        public GoalBase()
        {
        }

        public abstract float GetPriority();
        public abstract IState GetEffects();
        protected abstract bool ActiveCondition();
        public abstract bool IsGoalComplete();

        public void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate)
        {
            _onActivate = onActivate;
        }

        public void AddGoalInActivateListener(Action<IGoal<TGoal>> onInActivate)
        {
            _onInActivate = onInActivate;
        }

        public void UpdateData()
        {
            if (ActiveCondition())
            {
                _onActivate(this);
            }
            else
            {
                _onInActivate(this);
            }
        }
    }
}
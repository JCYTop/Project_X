/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/02/29 19:55:22
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    public abstract class GoalBase<TGoal> : IGoal<TGoal>
    {
        private Action<IGoal<TGoal>> onActivate;
        private Action<IGoal<TGoal>> onInactivate;
        public TGoal Label { get; }

        public int GetPriority()
        {
            throw new NotImplementedException();
        }

        public IState GetEffects()
        {
            throw new NotImplementedException();
        }

        public IState GetActiveCondition()
        {
            throw new NotImplementedException();
        }

        public bool IsGoalComplete()
        {
            throw new NotImplementedException();
        }

        public void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate)
        {
            throw new NotImplementedException();
        }

        public void AddGoalInactivateListener(Action<IGoal<TGoal>> onInactivate)
        {
            throw new NotImplementedException();
        }

        public void UpdateData()
        {
            throw new NotImplementedException();
        }
    }
}
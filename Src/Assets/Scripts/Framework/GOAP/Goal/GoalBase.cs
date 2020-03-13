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

namespace Framework.GOAP
{
    /// <summary>
    /// 加载配置文件
    /// 生成每一个具体的GoalBase类
    /// GoalBase 生成一个具体的Goal类
    /// </summary>
    /// <typeparam name="TGoal"></typeparam>
    public abstract class GoalBase<TAction, TGoal> : IGoal<TGoal>
    {
        private IAgent<TAction, TGoal> agent;
        private IState effects;
        private IState activeCondition;
        private Action<IGoal<TGoal>> onActivate;
        private Action<IGoal<TGoal>> onInactivate;
        public TGoal Label { get; }

        public GoalBase(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
            effects = InitEffects();
            activeCondition = InitCondition();
        }

        public IState GetEffects()
        {
            return effects;
        }

        public IState GetActiveCondition()
        {
            return activeCondition;
        }

        public bool IsGoalComplete()
        {
            throw new NotImplementedException();
        }

        public void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate)
        {
            this.onActivate = onActivate;
        }

        public void AddGoalInactivateListener(Action<IGoal<TGoal>> onInactivate)
        {
            this.onInactivate = onInactivate;
        }

        public void UpdateData()
        {
            throw new NotImplementedException();
        }

        public abstract IState InitEffects();
        public abstract IState InitCondition();
        public abstract int GetPriority();
    }
}
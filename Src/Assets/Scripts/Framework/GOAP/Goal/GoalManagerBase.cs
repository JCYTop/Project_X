/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalManagerBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/02/29 18:25:42
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace GOAP
{
    public abstract class GoalManagerBase<TAction, TGoal> : IGoalManager<TGoal>
    {
        protected IAgent<TAction, TGoal> agent;
        private Dictionary<TGoal, IGoal<TGoal>> goalsDic;
        private List<IGoal<TGoal>> activeGoals;
        public IGoal<TGoal> CurrentGoal { get; }

        public GoalManagerBase(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
            CurrentGoal = null;
            goalsDic = new Dictionary<TGoal, IGoal<TGoal>>();
            activeGoals = new List<IGoal<TGoal>>();
            InitGoals();
        }

        /// <summary>
        /// 初始化当前代理的目标
        /// </summary>
        protected abstract void InitGoals();

        public void AddGoal(TGoal goalLabel)
        {
            throw new System.NotImplementedException();
        }

        public IGoal<TGoal> GetGoal(TGoal goalLabel)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveGoal(TGoal goalLabel)
        {
            throw new System.NotImplementedException();
        }

        public IGoal<TGoal> FindGoal()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateData()
        {
            throw new System.NotImplementedException();
        }
    }
}
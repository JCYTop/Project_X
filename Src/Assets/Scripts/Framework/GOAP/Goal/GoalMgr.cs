/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalMgr
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/02/29 18:25:42
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace Framework.GOAP
{
    public abstract class GoalMgr<TAction, TGoal> : IGoalMgr<TGoal>
    {
        protected IAgent<TAction, TGoal> agent;
        public abstract Dictionary<TGoal, IGoal<TGoal>> GoalsDic { get; }
        public abstract List<IGoal<TGoal>> ActiveGoals { get; }
        public abstract IGoal<TGoal> CurrentGoal { get; }

        public GoalMgr(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
        }

        /// <summary>
        /// 初始化当前代理的目标
        /// </summary>
        protected abstract void InitGoals();

        public void AddGoal(IGoal<TGoal> goal)
        {
            if (!GoalsDic.ContainsKey(goal.Label))
            {
                goal.AddGoalActivateListener((activeGoal) =>
                {
                    //TODO 激活之后做的事情
                });
                goal.AddGoalInactivateListener((activeGoal) =>
                {
                    //TODO 未被激活之后做的事情
                });
                GoalsDic.Add(goal.Label, goal);
            }
        }

        public void RemoveGoal(TGoal goalLabel)
        {
            GoalsDic.RemoveDictionaryElements(goalLabel);
        }

        public IGoal<TGoal> GetGoal(TGoal goalLabel)
        {
            return GoalsDic.GetDictionaryValue(goalLabel);
        }

        /// <summary>
        /// 核心方法 *** 
        /// </summary>
        /// <returns></returns>
        public abstract IGoal<TGoal> FindGoal();

        public void UpdateData()
        {
            throw new System.NotImplementedException();
        }

        public TGoalMgr GetGoalMgr<TGoalMgr>() where TGoalMgr : class
        {
            try
            {
                return this as TGoalMgr;
            }
            catch (Exception e)
            {
                LogTool.LogException(e);
                throw;
            }
        }
    }
}
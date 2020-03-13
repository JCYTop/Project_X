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

using System;
using System.Collections.Generic;

namespace Framework.GOAP
{
    public abstract class GoalMgrBase<TAction, TGoal> : IGoalMgr<TGoal>
    {
        protected IAgent<TAction, TGoal> agent;
        public abstract Dictionary<TGoal, IGoal<TGoal>> GoalsDic { get; }
        public abstract List<IGoal<TGoal>> ActiveGoals { get; }
        public abstract IGoal<TGoal> CurrentGoal { get; }

        public GoalMgrBase(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
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
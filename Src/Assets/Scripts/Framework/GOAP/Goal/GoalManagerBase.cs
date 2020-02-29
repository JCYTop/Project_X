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

namespace GOAP
{
    public class GoalManagerBase<TAction, TGoal> : IGoalManager<TGoal>
    {
        private IAgent<TAction> agent;
        public IGoal<TGoal> CurrentGoal { get; }

        public GoalManagerBase(IAgent<TAction> agent)
        {
            this.agent = agent;
            CurrentGoal = null;
        }

        public IGoal<TGoal> GetGoal(TGoal goalLabel)
        {
            throw new System.NotImplementedException();
        }

        public void AddGoal(TGoal goalLabel)
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
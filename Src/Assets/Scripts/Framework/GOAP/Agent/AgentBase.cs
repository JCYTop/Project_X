/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AgentBase
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 22:19:37
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    public abstract class AgentBase<TAction, TGoal> : IAgent<TAction, TGoal>
    {
        public IContext Context { get; }
        public IState AgentState { get; }
        public IActionManager<TAction> ActionManager { get; }
        public IGoalManager<TGoal> GoalManager { get; }

        public void RegiestEvent()
        {
            throw new System.NotImplementedException();
        }

        public void UnRegiestEvent()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateData()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
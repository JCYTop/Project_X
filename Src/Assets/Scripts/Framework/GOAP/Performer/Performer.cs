/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Performer
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/15 21:59:18
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace Framework.GOAP
{
    public abstract class Performer<TAction, TGoal> : IPerformer<TAction, TGoal>
    {
        private IAgent<TAction, TGoal> agent;

        public Performer(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
            this.agent.AgentActionMgr.AddActionCompleteListener(PlanActionComplete);
        }

        //计划完成了当前动作 
        private void PlanActionComplete(TAction actionLabel)
        {
            LogTool.Log($"下一步");
            //TODO 后续操作
//            if (planHandler.GetCurrentHandler().Label.ToString() == actionLabel.ToString())
//                planHandler.NextAction();
        }

        public void UpdateData()
        {
            throw new System.NotImplementedException();
        }

        public void Interruptible()
        {
            throw new System.NotImplementedException();
        }
    }
}
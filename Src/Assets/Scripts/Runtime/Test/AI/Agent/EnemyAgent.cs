/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     EnemyAgent
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/05 22:31:22
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace Framework.GOAP
{
    public class EnemyAgent : AgentBase<ActionTag, GoalTag>
    {
        private EnemyContext EnemyContext => Context.GetContext<EnemyContext>();
        public override bool IsAgentOver { get; set; } = false;

        public EnemyAgent(IContext context) : base(context)
        {
            //初始化到指定 --->>> Context 方便全局调用
            AgentStateMgr = new EnemyStateMgr();
            AgentActionMgr = new EnemyActionMgr(this);
            AgentGoalMgr = new EnemyGoalMgr(this);
        }

        public override void StartFSM()
        {
            TargetEvent(AgentStateMgr.StartStateEvent);
        }

        protected override void TargetEvent(string eventName)
        {
            EnemyContext.StateFsm.Fsm.Event(eventName);
        }
    }
}
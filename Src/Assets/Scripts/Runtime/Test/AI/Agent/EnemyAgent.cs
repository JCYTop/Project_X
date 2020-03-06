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

namespace GOAP
{
    public class EnemyAgent : AgentBase<ActionEnemyTag, GoalEnemyTag>
    {
        private EnemyContext enemyContext;
        public override bool IsAgentOver { get; set; } = false;

        public EnemyAgent(IContext context) : base(context)
        {
            //初始化到指定 --->>> Context
            enemyContext = Context.GetContext<EnemyContext>();
            AgentStateManager = new EnemyStateManager();
        }

        public override IState InitStateManager()
        {
//            AgentStateManager . 
            return default;
        }

        public override IActionManager<ActionEnemyTag> ActionManager()
        {
            throw new System.NotImplementedException();
        }

        public override IGoalManager<GoalEnemyTag> GoalManager()
        {
            throw new System.NotImplementedException();
        }

        protected override void TargetEvent(string eventName)
        {
            enemyContext.StateFsm.Fsm.Event(eventName);
        }
    }
}
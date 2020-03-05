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

using JetBrains.Annotations;

namespace GOAP
{
    public class EnemyAgent : AgentBase<ActionEnemyTag, GoalEnemyTag>
    {
        private EnemyContext enemyContext;
        public override bool IsAgentOver { get; set; } = false;

        public EnemyAgent(IContext context) : base(context)
        {
        }

        protected override IState InitAgentState()
        {
            //TODO 设置一个初始化的状态
            Context.GetContext<EnemyContext>();
            return null;
        }

        protected override IActionManager<ActionEnemyTag> InitActionManager()
        {
            throw new System.NotImplementedException();
        }

        protected override IGoalManager<GoalEnemyTag> InitGoalManager()
        {
            throw new System.NotImplementedException();
        }

        protected override void TargetEvent([NotNull] string eventName)
        {
            enemyContext.StateFsm.Fsm.Event(eventName);
        }
    }
}
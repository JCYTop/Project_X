using HutongGames.PlayMaker;

namespace Framework.GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI.Enemy")]
    public class EnemyIdleState : AIStateBase<EnemyContext, EnemyStateConfig>
    {
        private EnemyStateMgr EnemyStateMgr => GetContext.Agent.AgentStateMgr.GetStateMgr<EnemyStateMgr>();

        public override void Init()
        {
            EnemyStateMgr.StateSortList.AddSortListElement(StateConfig.Tag, this);
        }

        public override void Enter()
        {
            EnemyStateMgr.SetCurrActivity(StateConfig.Tag);
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }

        public override EnemyStateConfig GetData()
        {
            return StateConfig;
        }
    }
}
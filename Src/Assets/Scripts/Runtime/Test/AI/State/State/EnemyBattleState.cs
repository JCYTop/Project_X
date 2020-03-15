using HutongGames.PlayMaker;

namespace Framework.GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI.Enemy")]
    public class EnemyBattleState : AIState<EnemyContext, EnemyStateConfig>
    {
        private EnemyStateMgr EnemyStateMgr => GetContext.Agent.AgentStateMgr.GetStateMgr<EnemyStateMgr>();

        public override void AwakeState()
        {
            EnemyStateMgr.StateSortList.AddSortListElements(StateConfig.Tag, this);
        }

        public override void EnterState()
        {
            EnemyStateMgr.SetCurrActivity(StateConfig.Tag);
        }

        public override void ExecuteState()
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override EnemyStateConfig GetData()
        {
            return StateConfig;
        }
    }
}
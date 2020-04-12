using HutongGames.PlayMaker;

namespace Framework.GOAP
{
    [ActionCategory("AI.Enemy")]
    public class EnemyAlertState : AIState<EnemyContext, EnemyStateConfig>
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
        }

        public override void ExitState()
        {
        }

        public override EnemyStateConfig GetData()
        {
            return StateConfig;
        }
    }
}
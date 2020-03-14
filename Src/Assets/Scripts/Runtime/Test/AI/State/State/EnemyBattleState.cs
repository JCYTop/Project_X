using HutongGames.PlayMaker;

namespace Framework.GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI.Enemy")]
    public class EnemyBattleState : AIStateBase<EnemyContext, EnemyStateConfig>
    {
        private EnemyStateMgr EnemyStateMgr => GetContext.Agent.AgentStateMgr.GetStateMgr<EnemyStateMgr>();

        public override void Awake()
        {
            base.Awake();
            EnemyStateMgr.StateSortList.AddSortListElement(StateConfig.Tag, this);
        }

        public override void Enter()
        {
            EnemyStateMgr.SetCurrActivity(StateConfig.Tag);
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }

        public override EnemyStateConfig GetData()
        {
            return StateConfig;
        }
    }
}
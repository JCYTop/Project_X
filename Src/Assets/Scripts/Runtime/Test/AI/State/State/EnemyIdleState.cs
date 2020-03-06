using HutongGames.PlayMaker;

namespace GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI.Enemy")]
    public class EnemyIdleState : AIStateBase<EnemyContext, EnemyStateConfig>
    {
        private EnemyAgent enemyAgent;
        private EnemyStateManager enemyStateManager;

        public override void Init()
        {
            enemyAgent = GetContext.Agent.GetAgent<EnemyAgent>();
            enemyStateManager = enemyAgent.AgentStateManager.GetStateMgr<EnemyStateManager>();
            enemyStateManager.StateDic.AddSortListElement(StateConfig.Tag, this);
        }

        public override void Enter()
        {
            //TODO 进入之后要做的事情
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }

        public override void SetData(IState data)
        {
        }

        public override IState GetData()
        {
            return default;
        }
    }
}
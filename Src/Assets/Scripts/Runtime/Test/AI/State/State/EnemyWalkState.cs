using HutongGames.PlayMaker;

namespace GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI.Enemy")]
    public class EnemyWalkState : AIStateBase<EnemyContext, EnemyStateConfig>
    {
        private EnemyStateManager enemyStateManager;

        public override void Init()
        {
            enemyStateManager = GetContext.Agent.AgentStateManager.GetStateMgr<EnemyStateManager>();
            enemyStateManager.StateDic.AddSortListElement(StateConfig.Tag, this);
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }

        public override void SetData(IState data)
        {
            throw new System.NotImplementedException();
        }

        public override IState GetData()
        {
            throw new System.NotImplementedException();
        }
    }
}
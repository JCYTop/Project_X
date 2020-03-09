using HutongGames.PlayMaker;

namespace Framework.GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI.Enemy")]
    public class EnemyWalkState : AIStateBase<EnemyContext, EnemyStateConfig>
    {
        private EnemyStateManager EnemyStateManager => GetContext.Agent.AgentStateManager.GetStateMgr<EnemyStateManager>();

        public override void Init()
        {
            EnemyStateManager.StateSortList.AddSortListElement(StateConfig.Tag, this);
        }

        public override void Enter()
        {
            EnemyStateManager.SetCurrActivity(StateConfig.Tag);
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
using HutongGames.PlayMaker;
using UnityEngine;

namespace GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI.Enemy")]
    public class EnemyIdleState : AIStateBase<EnemyContext, EnemyStateConfig>
    {
        private EnemyStateManager enemyStateManager;

        public override void Init()
        {
            enemyStateManager = GetContext.Agent.AgentStateManager.GetStateMgr<EnemyStateManager>();
            enemyStateManager.StateSortList.AddSortListElement(StateConfig.Tag, this);
        }

        public override void Enter()
        {
            enemyStateManager.SetCurrActivity(StateConfig.Tag);
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
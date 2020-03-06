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
        private EnemyAgent enemyAgent;
        private EnemyStateManager enemyStateManager;

        public override void Init()
        {
            enemyStateManager = GetContext.Agent.AgentStateManager.GetStateMgr<EnemyStateManager>();
            enemyStateManager.StateDic.AddSortListElement(StateConfig.Tag, this);
        }

        public override void Enter()
        {
            Debug.Log("老子终于进来了");
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
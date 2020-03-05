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
        public override void Init()
        {
            GetContext.StateDic.AddSortListElement(StateConfig.Tag, this);
        }

        public override void Enter()
        {
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
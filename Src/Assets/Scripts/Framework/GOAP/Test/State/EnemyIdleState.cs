using HutongGames.PlayMaker;

namespace GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI/Enemy/Idle")]
    public class EnemyIdleState : AIStateBase<EnemyStateConfig>
    {
        public override void Init()
        {
            LogTool.Log(StateConfig.Tag.ToString(), LogEnum.NormalLog);
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
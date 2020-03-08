using System;

namespace GOAP
{
    public class EmenyDefaultActionHandler : ActionHandler<ActionEnemyTag>
    {
        public override ActionExcuteState ExcuteState { get; }

        public override void AddFinishCallBack(Action onFinishAction)
        {
            this.onFinishAction = onFinishAction;
        }

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
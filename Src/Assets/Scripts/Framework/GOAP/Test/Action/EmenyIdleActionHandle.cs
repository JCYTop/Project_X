using System;

namespace GOAP
{
    public class EmenyIdleActionHandle : ActionHandle<ActionTag, GoalTag>
    {
        public override ActionTag Label { get; }
        public override void AddFinishCallBack(Action onFinishAction)
        {
            throw new NotImplementedException();
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
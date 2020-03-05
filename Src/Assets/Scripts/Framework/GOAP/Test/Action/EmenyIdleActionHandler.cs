using System;

namespace GOAP
{
    public class EmenyIdleActionHandler : ActionHandler<ActionTag, GoalTag>
    {
        public override void Init<TAction, TGoal>(IAgent<TAction, TGoal> agent, IAction<TAction> action)
        {
            throw new NotImplementedException();
        }

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

        public override ActionExcuteState ExcuteState { get; }
        public override ActionTag Label { get; }
    }
}
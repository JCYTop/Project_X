namespace GOAP
{
    public class EnemyGoal : GoalBase<ActionTag, GoalTag>
    {
        public EnemyGoal(IAgent<ActionTag> agent) : base(agent)
        {
        }

        public override IState InitEffects()
        {
            throw new System.NotImplementedException();
        }

        public override IState InitActiveCondition()
        {
            throw new System.NotImplementedException();
        }

        public override int GetPriority()
        {
            throw new System.NotImplementedException();
        }
    }
}
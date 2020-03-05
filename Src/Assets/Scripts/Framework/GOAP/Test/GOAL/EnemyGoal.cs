namespace GOAP
{
    public class EnemyGoal : GoalBase<ActionCommonTag, GoalCommonTag>
    {
        public EnemyGoal(IAgent<ActionCommonTag, GoalCommonTag> agent) : base(agent)
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
namespace Framework.GOAP
{
    public class EnemyPerformer : Performer<ActionTag, GoalTag>
    {
        public EnemyPerformer(IAgent<ActionTag, GoalTag> agent) : base(agent)
        {
        }
    }
}
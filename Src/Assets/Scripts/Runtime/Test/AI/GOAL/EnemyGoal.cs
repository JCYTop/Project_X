namespace Framework.GOAP
{
    public class EnemyGoal : GoalBase<GoalTag, GoalElementTag>
    {
        public EnemyGoal(GoalTag tag, GoalConfigUnit<GoalElementTag> actionGroup) : base(tag, actionGroup)
        {
        }
    }
}
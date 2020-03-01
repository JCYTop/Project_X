namespace GOAP
{
    /// <summary>
    /// 这里存放Enemy每个具体的目标信息
    /// </summary>
    public class EnemyGoalConfigUnit : GoalConfigUnit<GoalConfigElementTag>
    {
        public int Priority;

        public override GoalConfigUnit<GoalConfigElementTag> Init()
        {
            var priority = new ValueAggregation(Priority);
            goalConfigUnitSet.Add(GoalConfigElementTag.Priority, priority);
            return this;
        }
    }
}
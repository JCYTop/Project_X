namespace GOAP
{
    /// <summary>
    /// 这里存放Enemy每个具体的目标信息
    /// </summary>
    public class EnemyGoalConfigUnit : GoalConfigUnit<GoalElementTag>
    {
        public int Priority;

        public override GoalConfigUnit<GoalElementTag> Init()
        {
            var priority = new ValueAggregation(Priority);
            goalConfigUnitSet.Add(GoalElementTag.Priority, priority);
            LogTool.Log($"{this.name} , GoalConfigUnit数据已经加载完成", LogEnum.AssetLog);
            return this;
        }
    }
}
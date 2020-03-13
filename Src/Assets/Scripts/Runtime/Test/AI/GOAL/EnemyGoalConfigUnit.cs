namespace Framework.GOAP
{
    /// <summary>
    /// 这里存放Enemy每个具体的目标信息
    /// </summary>
    public class EnemyGoalConfigUnit : GoalConfigUnit<GoalElementTag>
    {
        public override GoalConfigUnit<GoalElementTag> Init()
        {
            ADD(GoalElementTag.Priority, Priority);
            ADD(GoalElementTag.Conditon, Condition);
            ADD(GoalElementTag.Effects, Effets);
            LogTool.Log($"{this.name} , GoalConfigUnit数据已经加载完成", LogEnum.AssetLog);
            return this;
        }
    }
}
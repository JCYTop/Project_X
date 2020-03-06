namespace GOAP
{
    public class EnemyActionConfigUnit : ActionConfigUnit<ActionConfigElementTag>
    {
        public int Priority;

        public override ActionConfigUnit<ActionConfigElementTag> Init()
        {
            var priority = new ValueAggregation(Priority);
            ActionConfigUnitSet.Add(ActionConfigElementTag.Priority, priority);
            LogTool.Log($"{this.name} , ActionConfigUnit数据已经加载完成", LogEnum.AssetLog);
            return this;
        }
    }
}
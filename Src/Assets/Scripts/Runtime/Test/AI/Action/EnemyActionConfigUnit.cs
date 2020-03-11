namespace Framework.GOAP
{
    public class EnemyActionConfigUnit : ActionConfigUnit<ActionElementTag>
    {
        [Rename("权重")] public int Priority;
        [Rename("是否可打断")] public bool IsInterruptible = false;
        [Rename("消耗")] public int Cost;

        public override ActionConfigUnit<ActionElementTag> Init()
        {
            var priority = new ValueAggregation(Priority);
            ActionConfigUnitSet.Add(ActionElementTag.Priority, priority);
            var interruptible = new BoolAggregation(IsInterruptible);
            ActionConfigUnitSet.Add(ActionElementTag.Interruptible, interruptible);
            var cost = new ValueAggregation(Cost);
            ActionConfigUnitSet.Add(ActionElementTag.Cost, cost);
            LogTool.Log($"{this.name} , ActionConfigUnit数据已经加载完成", LogEnum.AssetLog);
            return this;
        }
    }
}
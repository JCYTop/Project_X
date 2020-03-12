namespace Framework.GOAP
{
    public class EnemyActionConfigUnit : ActionConfigUnit<ActionElementTag>
    {
        [Rename("权重")] public int Priority;
        [Rename("是否可打断")] public bool IsInterruptible = false;
        [Rename("消耗")] public int Cost;

        public override ActionConfigUnit<ActionElementTag> Init()
        {
            ActionConfigUnitSet.Add(ActionElementTag.Priority, Priority);
            ActionConfigUnitSet.Add(ActionElementTag.Interruptible, IsInterruptible);
            ActionConfigUnitSet.Add(ActionElementTag.Cost, Cost);
            LogTool.Log($"{this.name} , ActionConfigUnit数据已经加载完成", LogEnum.AssetLog);
            return this;
        }
    }
}
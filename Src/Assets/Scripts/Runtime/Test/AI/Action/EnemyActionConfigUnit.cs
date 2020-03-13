namespace Framework.GOAP
{
    public class EnemyActionConfigUnit : ActionConfigUnit<ActionElementTag>
    {
        public override ActionConfigUnit<ActionElementTag> Init()
        {
            ADD(ActionElementTag.Priority, Priority);
            ADD(ActionElementTag.Interruptible, IsInterruptible);
            ADD(ActionElementTag.Cost, Cost);
            ADD(ActionElementTag.ActionUnityGroups, ActionUnityGroups);
            ADD(ActionElementTag.Preconditions, Preconditions);
            ADD(ActionElementTag.Effects, Effects);
            LogTool.Log($"{this.name} , ActionConfigUnit数据已经加载完成", LogEnum.AssetLog);
            return this;
        }
    }
}
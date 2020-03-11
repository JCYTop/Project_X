using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyActionConfigUnit : ActionConfigUnit<ActionElementTag>
    {
        [Header("权重")] public int Priority;
        [Header("是否可打断")] public bool IsInterruptible = false;
        [Header("消耗")] public int Cost;

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
using UnityEngine;

namespace GOAP
{
    public class EnemyActionConfigUnit : ActionConfigUnit<ActionCommonElementTag>
    {
        [Header("权重")] public int Priority;
        [Header("是否可打断")] public bool IsInterruptible = false;

        public override ActionConfigUnit<ActionCommonElementTag> Init()
        {
            var priority = new ValueAggregation(Priority);
            ActionConfigUnitSet.Add(ActionCommonElementTag.Priority, priority);
            var interruptible = new BoolAggregation(IsInterruptible);
            ActionConfigUnitSet.Add(ActionCommonElementTag.Interruptible, interruptible);
            LogTool.Log($"{this.name} , ActionConfigUnit数据已经加载完成", LogEnum.AssetLog);
            return this;
        }
    }
}
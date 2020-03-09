using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyActionConfigUnit : ActionConfigUnit<EnemyActionElementTag>
    {
        [Header("权重")] public int Priority;
        [Header("是否可打断")] public bool IsInterruptible = false;
        [Header("消耗")] public int Cost;

        public override ActionConfigUnit<EnemyActionElementTag> Init()
        {
            var priority = new ValueAggregation(Priority);
            ActionConfigUnitSet.Add(EnemyActionElementTag.Priority, priority);
            var interruptible = new BoolAggregation(IsInterruptible);
            ActionConfigUnitSet.Add(EnemyActionElementTag.Interruptible, interruptible);
            var cost = new ValueAggregation(Cost);
            ActionConfigUnitSet.Add(EnemyActionElementTag.Cost, cost);
            LogTool.Log($"{this.name} , ActionConfigUnit数据已经加载完成", LogEnum.AssetLog);
            return this;
        }
    }
}
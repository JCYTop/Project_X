using System;

namespace GOAP
{
    /// <summary>
    /// 用在具体的生成类
    /// </summary>
    public class EnemyAction : ActionBase<ActionEnemyTag, ActionCommonElementTag>
    {
        public override bool CanInterruptiblePlan
        {
            get
            {
                var interruptible = ActionGroup.ActionConfigUnitSet.GetSortListValue(ActionCommonElementTag.Interruptible);
                LogTool.Log($"{interruptible.TypeName}");
                return false;
            }
        }

        public EnemyAction(ActionEnemyTag tag, ActionConfigUnit<ActionCommonElementTag> actionGroup) : base(tag, actionGroup)
        {
        }


        protected override IState InitEffects()
        {
            throw new System.NotImplementedException();
        }

        protected override IState InitPreConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
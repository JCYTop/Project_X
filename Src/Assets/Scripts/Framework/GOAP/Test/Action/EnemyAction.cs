namespace GOAP
{
    /// <summary>
    /// 用在具体的生成类
    /// </summary>
    public class EnemyAction : ActionBase<ActionCommonTag, GoalCommonTag>
    {
        public EnemyAction(ActionConfigUnit<GoalCommonTag> configUnit) : base(configUnit)
        {
        }

        public override ActionCommonTag Label { get; }

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
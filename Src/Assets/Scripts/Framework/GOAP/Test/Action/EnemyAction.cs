namespace GOAP
{
    /// <summary>
    /// 用在具体的生成类
    /// </summary>
    public class EnemyAction : ActionBase<ActionTag, GoalTag>
    {
        public EnemyAction(ActionConfigUnit<GoalTag> configUnit) : base(configUnit)
        {
        }

        public override ActionTag Label { get; }

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
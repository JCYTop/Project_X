namespace GOAP
{
    /// <summary>
    /// 用在具体的生成类
    /// </summary>
    public class EnemyAction : ActionBase<ActionEnemyTag, GoalEnemyTag>
    {
        public EnemyAction(ActionConfigUnit<GoalEnemyTag> configUnit) : base(configUnit)
        {
        }

        public override ActionEnemyTag Label { get; }

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
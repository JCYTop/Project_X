namespace GOAP
{
    public class EnemyAction:ActionBase <ActionTag> 
    {
        public EnemyAction(IAgent<ActionTag> agent) : base(agent)
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
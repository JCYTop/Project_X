namespace Framework.GOAP
{
    public class EnemyGoalMgr : GoalMgrBase<ActionTag, GoalTag>
    {
        public EnemyAgent EnemyAgent => agent.GetAgent<EnemyAgent>();
        public EnemyContext EnemyContext => EnemyAgent.Context.GetContext<EnemyContext>();

        public EnemyGoalMgr(IAgent<ActionTag, GoalTag> agent) : base(agent)
        {
        }

        protected override void InitGoals()
        {
            EnemyContext.GoalConfig.Init();
        }
    }
}
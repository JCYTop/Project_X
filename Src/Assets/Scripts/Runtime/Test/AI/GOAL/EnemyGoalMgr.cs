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
            var list = EnemyContext.GoalConfig.Init();
            foreach (var unit in list)
            {
                var goal = new EnemyGoal(unit.Key, unit.Value);
            }
        }
    }
}
namespace Framework.GOAP
{
    // TODO --->Performer ---> PlanHandler ---> Plan
    public class EnemyPerformer : Performer<ActionTag, GoalTag>
    {
        private IGoal<GoalTag> cacheGoal;

        public EnemyPerformer(IAgent<ActionTag, GoalTag> agent) : base(agent)
        {
            this.agent.AgentActionMgr.AddActionCompleteListener((actionLabel) =>
            {
                LogTool.Log($"下一步");
                //TODO 后续操作
            });
            this.planHandler = new EnemyPlanHandler(new EnemyTreePlanner(agent));
            this.planHandler.AddCompleteCallBack(() =>
            {
                //计划完成
                LogTool.Log($"计划完成");
                // TODO 计划完成做该做的事情
            });
        }

        public override void UpdateData()
        {
            var goals = agent.AgentGoalMgr.FindGoals();
            if (planHandler.IsComplete || cacheGoal == null || cacheGoal != goals.GoalsSortPriority())
            {
                if (goals.Count <= 0)
                {
                    LogTool.Log($"无计划制定");
                    planHandler.CurrActionHandlers.Clear();
                    planHandler.CurrActionHandlers.AddLast(agent.AgentActionMgr.GetHandler(ActionTag.Idle));
                    return;
                }

                if (planHandler.CurrGoal == null || goals.GoalsSortPriority() != planHandler.CurrGoal)
                {
                    //目标没有时候执行
                    //目标发生改变时候执行
                    planHandler.CurrGoal = goals.GoalsSortPriority();
                    cacheGoal = planHandler.CurrGoal;
                    planHandler.CurrActionHandlers = planHandler.Planner.BuildPlan(planHandler.CurrGoal);
                }
                else
                {
                    LogTool.Log($"目标相同 {planHandler.CurrGoal}");
                }
            }

            agent.AgentActionMgr.ExcuteHandler(planHandler.HandlerAction());
        }

        public override void Interruptible()
        {
            throw new System.NotImplementedException();
        }
    }
}
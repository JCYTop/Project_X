namespace Framework.GOAP
{
    // TODO --->Performer ---> PlanHandler ---> Plan
    public class EnemyPerformer : Performer<ActionTag, GoalTag>
    {
        public EnemyPerformer(IAgent<ActionTag, GoalTag> agent) : base(agent)
        {
            this.agent.AgentActionMgr.AddActionCompleteListener((actionLabel) =>
            {
                //TODO 计划完成了当前动作 
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
            if (planHandler.IsComplete)
            {
                LogTool.Log($"planHandler 显示可以创建新的计划 {planHandler.IsComplete}");
                BuildPlan();
            }

            //TODO 构成回环 明天完成
            agent.AgentActionMgr.ExcuteHandler(planHandler.HandlerAction());
        }

        public override void Interruptible()
        {
            throw new System.NotImplementedException();
        }

        public override void BuildPlan()
        {
            var goals = agent.AgentGoalMgr.FindGoals();
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
                planHandler.CurrActionHandlers = planHandler.Planner.BuildPlan(planHandler.CurrGoal);
            }
            else
            {
                LogTool.Log($"目标相同 {planHandler.CurrGoal}");
            }
        }
    }
}
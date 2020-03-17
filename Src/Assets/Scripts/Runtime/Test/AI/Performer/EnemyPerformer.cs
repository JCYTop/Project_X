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
            //TODO Handler 最干净设置
            this.planHandler = new EnemyPlanHandler();
            this.planHandler.AddCompleteCallBack(() =>
            {
                //计划完成
                LogTool.Log($"计划完成");
                // TODO 计划完成做该做的事情
            });
            //TODO Planner 最干净
            //TODO Planner 要放到Hander吗？
            this.planner = new EnemyPlanner();
        }

        public override void UpdateData()
        {
            throw new System.NotImplementedException();
        }

        public override void Interruptible()
        {
            throw new System.NotImplementedException();
        }
    }
}
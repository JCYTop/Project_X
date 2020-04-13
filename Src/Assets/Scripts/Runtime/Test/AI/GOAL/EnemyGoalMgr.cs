using System.Collections.Generic;

namespace Framework.GOAP
{
    public class EnemyGoalMgr : GoalMgr<ActionTag, GoalTag>
    {
        private Dictionary<GoalTag, IGoal<GoalTag>> goalsDic;
        private List<IGoal<GoalTag>> activeGoals;
        private IGoal<GoalTag> currentGoal;
        public EnemyAgent EnemyAgent => agent.GetAgent<EnemyAgent>();
        public EnemyContext EnemyContext => EnemyAgent.Context.GetContext<EnemyContext>();
        public override Dictionary<GoalTag, IGoal<GoalTag>> GoalsDic => goalsDic;
        public override List<IGoal<GoalTag>> ActiveGoals => activeGoals;
        public override IGoal<GoalTag> CurrentGoal => currentGoal;

        public EnemyGoalMgr(IAgent<ActionTag, GoalTag> agent) : base(agent)
        {
            goalsDic = new Dictionary<GoalTag, IGoal<GoalTag>>();
            activeGoals = new List<IGoal<GoalTag>>();
            InitGoals();
        }

        protected override void InitGoals()
        {
            var list = EnemyContext.GoalConfig.Init();
            foreach (var unit in list)
            {
                var goal = new EnemyGoal(unit.Key, unit.Value);
                goal.AddGoalActivateListener((activeGoal) =>
                {
                    //TODO 激活之后做的事情
                });
                goal.AddGoalInactivateListener((activeGoal) =>
                {
                    //TODO 未被激活之后做的事情
                });
                GoalsDic.Add(goal.Label, goal);
            }
        }

        public override List<IGoal<GoalTag>> FindGoals()
        {
            var goalList = new List<IGoal<GoalTag>>();
            var tmpCondition = new List<CondtionTag>();
            foreach (var goal in GoalsDic.Values)
            {
                tmpCondition.Clear();
                var isAdd = true;
                if (goal.Condition.Count > 0)
                {
                    foreach (var assembly in goal.Condition)
                    {
                        tmpCondition.Add(assembly.ElementTag);
                        isAdd = EnemyContext.Condition.GetCondition<EnemyCondition>().ConditionMap.GetDictionaryValue(assembly.ElementTag);
                        if (!isAdd)
                            break;
                    }

                    if (goal.Target.Count > 0)
                    {
                        foreach (var assembly in goal.Target)
                        {
                            if (tmpCondition.Contains(assembly.ElementTag))
                                continue;
                            isAdd = !EnemyContext.Condition.GetCondition<EnemyCondition>().ConditionMap.GetDictionaryValue(assembly.ElementTag);
                            if (!isAdd)
                                break;
                        }
                    }
                }

                if (isAdd)
                    goalList.AddListElement(goal);
            }

            return goalList;
        }
    }
}
using System.Collections.Generic;

namespace Framework.GOAP
{
    public class EnemyPlanHandler : PlanHandler<ActionTag, GoalTag>
    {
        public EnemyPlanHandler(IPlanner<ActionTag, GoalTag> planner) : base(planner)
        {
            this.CurrActionHandlers = new LinkedList<IActionHandler<ActionTag>>();
        }
    }
}
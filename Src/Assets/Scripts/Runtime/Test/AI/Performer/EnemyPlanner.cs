using System.Collections.Generic;

namespace Framework.GOAP
{
    public class EnemyPlanner : Planner<ActionTag, GoalTag>
    {
        public override LinkedList<IActionHandler<ActionTag>> BuildPlan(IGoal<GoalTag> goal)
        {
            var link = new LinkedList<IActionHandler<ActionTag>>();
            return default;
        }
    }
}
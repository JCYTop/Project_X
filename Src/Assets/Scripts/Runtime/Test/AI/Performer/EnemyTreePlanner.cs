using System.Collections.Generic;
using System.Linq;
using Base.MultiTree;

namespace Framework.GOAP
{
    /// <summary>
    /// 构建一个计划 Tree 树
    /// </summary>
    public class EnemyTreePlanner : Planner<ActionTag, GoalTag>
    {
        public EnemyTreePlanner(IAgent<ActionTag, GoalTag> agent) : base(agent)
        {
        }

        /// <summary>
        /// 目标由GoalMgr提供 
        /// </summary>
        /// <param name="goal"></param>
        /// <returns></returns>
        public override LinkedList<IActionHandler<ActionTag>> BuildPlan(List<IGoal<GoalTag>> goals)
        {
            LogTool.Log($"制定计划");
            //创建一个队列开始
            var plan = new LinkedList<IActionHandler<ActionTag>>();
            if (goals == null)
                return plan;
            var goal = GetStartGoal();
            BuildActionTree();
            return plan;

            //构建Action树
            void BuildActionTree()
            {
                //初始化默认父节点
                var topTree = new MultiTreeNode<IActionHandler<ActionTag>>(null);
                var currNode = topTree;
                var currNodeCondition = goal.Condition;
                var currkeys = agent.Context.Condition.GetDiffecentCondition(goal).ToList();
                //循环创建多叉树
                while (!IsNodeEnd())
                {
                    var handlers = GetSubHandlers();
                    //获取状态差异
                }

                //获取当前节点所有可能的子节点
                List<IActionHandler<ActionTag>> GetSubHandlers()
                {
                    var handlers = new List<IActionHandler<ActionTag>>();
                    if (currNode == null)
                        return handlers;
                    var maps = agent.AgentActionMgr.EffectActionMap;
                    //下面进行查找相对应的Handler 
                    foreach (var key in currkeys)
                    {
                        if (maps.ContainsKey(key))
                        {
                            foreach (var handler in maps[key])
                            {
                                //筛选能够执行的动作
                                if (!handlers.Contains(handler) &&
                                    handler.Action.GetEffectsValue(key).IsRight == currNodeCondition.GetDiffecentCondition(key).IsRight)
                                {
                                    handlers.Add(handler);
                                }
                            }
                        }
                        else
                        {
                            LogTool.LogError($"当前没有动作能够实现从当前状态切换到目标状态，无法实现的键值为： {key}");
                        }
                    }

                    return handlers;
                }

                //判断是否停止创建多叉树
                //退出构建树的条件
                bool IsNodeEnd()
                {
                    if (currNode == null)
                        return true;
                    if (currNode.Data == null)
                        return false;
                    if (GetStateDifferecnceNum())
                        return true;
                    return false;

                    bool GetStateDifferecnceNum()
                    {
                        currNode.Data.Action.Effects
                    }
                }
            }

            //构建目标树
            IGoal<GoalTag> GetStartGoal()
            {
                return goals.GoalsSortPriority();
            }
        }
    }
}
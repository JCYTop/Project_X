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
            var plan = new LinkedList<IActionHandler<ActionTag>>();
            if (goals.Count <= 0)
            {
                plan.AddLast(agent.AgentActionMgr.GetHandler(ActionTag.Idle));
                return plan;
            }

            var goal = goals.GoalsSortPriority();
            var lastAction = BuildActionTree();
            if (lastAction != null)
            {
                while (lastAction.Data != null)
                {
                    plan.AddLast(lastAction.Data);
                    lastAction = lastAction.Parent;
                }
            }
            else
                LogTool.LogError($"当前节点为空");

            LogTool.Log($"---------------最终生成计划------------");
            foreach (var handler in plan)
            {
                LogTool.Log($"计划项： {handler.Action.Label}");
            }

            LogTool.Log($"计划结束");
            return plan;

            //构建Action树
            MultiTreeNode<IActionHandler<ActionTag>> BuildActionTree()
            {
                //初始化默认父节点
                var topTree = new MultiTreeNode<IActionHandler<ActionTag>>(null);
                topTree.OtherData.AddHashtableElement("CurrCost", 0);
                var currNode = topTree;
                var ResetTarget = agent.Context.Condition.GetDiffecentTargetTags(goal.Target).ToList();
                var currKeys = agent.Context.Condition.GetDiffecentTargetTags(goal).ToList();
                MultiTreeNode<IActionHandler<ActionTag>> subNode = null;
                MultiTreeNode<IActionHandler<ActionTag>> cheapestNode = null;
                //循环创建多叉树
                while (!IsNodeEnd(currKeys))
                {
                    //获取状态差异的Handlers
                    var handlers = GetSubHandlers();
                    foreach (var handler in handlers)
                    {
                        subNode = new MultiTreeNode<IActionHandler<ActionTag>>(handler);
                        subNode.OtherData.AddHashtableElement("CurrCost", GetAllCost());
                        subNode.Parent = currNode;
                        cheapestNode = GetCheapestNode(subNode, cheapestNode);
                    }

                    currNode = cheapestNode;
                    currKeys = AIConditionExtend
                        .GetDiffecentCondition(ResetTarget, currNode.Data.Action.Effects)
                        .GetDiffecentConditionTag()
                        .ToList();
                    ResetTarget = AIConditionExtend
                        .GetDiffecentCondition(ResetTarget, currNode.Data.Action.Effects)
                        .ToList();
                    cheapestNode = null;
                }

                return currNode;

                int GetAllCost()
                {
                    var configCost = 0;
                    if (subNode.Data != null)
                        configCost = subNode.Data.Action.Cost;
                    var currCost = currNode.OtherData.GetHashtableElement<int>("CurrCost");
                    //上一个节点消耗+配置消耗+比较之前节点消耗
                    return currCost + configCost + AIConditionExtend.GetDiffecentCondition(ResetTarget, subNode.Data.Action.Effects).Count;
                }

                //获取当前节点所有可能的子节点
                List<IActionHandler<ActionTag>> GetSubHandlers()
                {
                    var handlers = new List<IActionHandler<ActionTag>>();
                    if (currNode == null)
                        return handlers;
                    var maps = agent.AgentActionMgr.EffectActionMap;
                    //下面进行查找相对应的Handler 
                    foreach (var key in currKeys)
                    {
                        if (maps.ContainsKey(key))
                        {
                            foreach (var handler in maps[key])
                            {
                                //筛选能够执行的动作
                                if (!handlers.Contains(handler) &&
                                    handler.Action.GetEffectsValue(key).IsRight == ResetTarget.GetDiffecentCondition(key).IsRight)
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

                    handlers = handlers.OrderByDescending(handler => handler.Action.Priority).ToList();
                    return handlers;
                }
            }
        }

        /// <summary>
        /// 退出构建树的条件,判断是否停止创建多叉树 
        /// </summary>
        /// <returns></returns>
        private bool IsNodeEnd(List<CondtionTag> currKeys)
        {
            if (currKeys == null)
                return true;
            if (currKeys.Count <= 0)
                return true;
            return false;
        }

        private MultiTreeNode<IActionHandler<ActionTag>> GetCheapestNode(MultiTreeNode<IActionHandler<ActionTag>> left,
            MultiTreeNode<IActionHandler<ActionTag>> right)
        {
            if (left == null || left.Data == null)
                return right;
            if (right == null || right.Data == null)
                return left;
            if (left.OtherData.GetHashtableElement<int>("CurrCost") > right.OtherData.GetHashtableElement<int>("CurrCost"))
            {
                return right;
            }
            else if (left.OtherData.GetHashtableElement<int>("CurrCost") < right.OtherData.GetHashtableElement<int>("CurrCost"))
            {
                return left;
            }
            else
            {
                if (left.Data.Action.Priority > right.Data.Action.Priority)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
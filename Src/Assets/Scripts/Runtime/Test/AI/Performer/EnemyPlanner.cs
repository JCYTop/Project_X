using System.Collections.Generic;
using System.Linq;

namespace Framework.GOAP
{
    public class EnemyPlanner : Planner<ActionTag, GoalTag>
    {
        public EnemyPlanner(IAgent<ActionTag, GoalTag> agent) : base(agent)
        {
        }

        //TODO 需要理解具体过程
        //TODO 以下皆为实验体
        public override LinkedList<IActionHandler<ActionTag>> BuildPlan(IGoal<GoalTag> goal)
        {
//            LogTool.Log($"制定计划");
//            LogTool.Log($"---------------当前代理状态------------");
//            LogTool.Log(agent.AgentStateMgr.CurrState.ToString());
//            LogTool.Log("---------------------------");
//            //创建一个队列开始
//            var plan = new LinkedList<IActionHandler<ActionTag>>();
//            if (goal == null)
//                return plan;

            return default;
        }

//        /// <summary>
//        /// 核心子方法
//        /// </summary>
//        /// <param name="goal"></param>
//        /// <returns></returns>
//        private TreeNode<ActionTag> Plan(IGoal<GoalTag> goal)
//        {
//            //创建一个树
//            var tree = new Tree<ActionTag>();
//            var topNode = CreateTopNode(tree, goal);
//            //获取最优节点
//            TreeNode<ActionTag> cheapestNode = null;
//            //子节点
//            TreeNode<ActionTag> subNode = null;
//            var currentNode = topNode;
//            while (!IsEnd(currentNode))
//            {
//                //获取所有的子行为
//                var handlers = GetSubHandlers(currentNode);
//                LogTool.Log($"以下纯正打Log");
//                LogTool.Log($"---------------currentNode: {currentNode.ID} -----------------");
//                foreach (var handler in handlers)
//                {
//                    LogTool.Log("计划子行为:" + handler.Action.Label + "  优先级：" + handler.Action.Priority);
//                }
//
//                LogTool.Log($"--------------------------------");
//                foreach (var handler in handlers)
//                {
//                    subNode = tree.CreateNode(handler);
//                    SetNodeState(currentNode, subNode);
//                    subNode.Cost = GetCost(subNode);
//                    subNode.ParentNode = currentNode;
//                    cheapestNode = GetCheapestNode(subNode, cheapestNode);
//                }
//            }
//            currentNode = cheapestNode;
//            return currentNode;
//        }
//
//        private bool IsEnd(TreeNode<ActionTag> currentNode)
//        {
//            if (currentNode == null)
//                return true;
//            if (GetStateDifferecnceNum(currentNode) == 0)
//                return true;
//            return false;
//        }
//
//        private TreeNode<ActionTag> CreateTopNode(Tree<ActionTag> tree, IGoal<GoalTag> goal)
//        {
//            var topNode = tree.CreateNode();
//            topNode.GoalState.Set(goal.GetEffects());
//            topNode.Cost = GetCost(topNode);
//            SetNodeCurrentState(topNode);
//            return topNode;
//        }
//
//        #region 获取消耗
//
//        private int GetCost(TreeNode<ActionTag> node)
//        {
//            var actionCost = 0;
//            if (node.ActionHandler != null)
//                actionCost = node.ActionHandler.Action.Cost;
//            return node.Cost + GetStateDifferecnceNum(node) + actionCost;
//        }
//
//        private int GetStateDifferecnceNum(TreeNode<ActionTag> node)
//        {
//            return node.CurrentState.GetValueDifferences(node.GoalState).Count;
//        }
//
//        #endregion
//
//        /// <summary>
//        /// 把GoalState中有且CurrentState没有的添加到CurrentState中
//        /// 数据从agent的当前状态中获取
//        /// </summary>
//        /// <param name="node"></param>
//        private void SetNodeCurrentState(TreeNode<ActionTag> node)
//        {
//            var keys = node.CurrentState.GetNotExistKeys(node.GoalState);
//            foreach (string key in keys)
//            {
//                node.CurrentState.Set(key, agent.AgentState.Get(key));
//            }
//        }
//
//        /// <summary>
//        /// 获取所有的子节点行为
//        /// 通过比对当前的节点和给予的节点进行返回Handler队列
//        /// </summary>
//        /// <param name="node"></param>
//        /// <returns></returns>
//        private List<IActionHandler<ActionTag>> GetSubHandlers(TreeNode<ActionTag> node)
//        {
//            var handlers = new List<IActionHandler<ActionTag>>();
//            if (node == null)
//                return handlers;
//            //获取状态差异
//            var keys = node.CurrentState.GetValueDifferences(node.GoalState);
//            var map = agent.AgentActionMgr.EffectActionMap;
//            foreach (var key in keys)
//            {
//                if (map.ContainsKey(key))
//                {
//                    foreach (var handler in map[key])
//                    {
//                        //筛选能够执行的动作
//                        if (!handlers.Contains(handler) && handler.Action.Effects.Get(key) == node.GoalState.Get(key))
//                        {
//                            handlers.Add(handler);
//                        }
//                    }
//                }
//                else
//                {
//                    LogTool.Log($"当前没有动作能够实现从当前状态切换到目标状态，无法实现的键值为： {key}");
//                }
//            }
//
//            //进行优先级排序
//            handlers = handlers.OrderByDescending(u => u.Action.Priority).ToList();
//            return handlers;
//        }
//
//        private void SetNodeState(TreeNode<ActionTag> currentNode, TreeNode<ActionTag> subNode)
//        {
//            if (subNode.ID > TreeNode<ActionTag>.DEFAULT_ID)
//            {
//                var subAction = subNode.ActionHandler.Action;
//                //首先复制当前节点的状态
//                subNode.CopyState(currentNode);
//                //查找action的effects，和goal中也存在
//                var data = subNode.GoalState.GetSameData(subAction.Effects);
//                //那么就把这个状态添加到节点的当前状态中
//                subNode.CurrentState.Set(data);
//                //把action的先决条件存在goalState中不存在的键值添加进去
//                foreach (var key in subAction.Preconditions.GetKeys())
//                {
//                    if (!subNode.GoalState.ContainKey(key))
//                    {
//                        subNode.GoalState.Set(key, subAction.Preconditions.Get(key));
//                    }
//                }
//
//                SetNodeCurrentState(subNode);
//            }
//        }
//
//        private TreeNode<ActionTag> GetCheapestNode(TreeNode<ActionTag> nodeA, TreeNode<ActionTag> nodeB)
//        {
//            if (nodeA == null || nodeA.ActionHandler == null)
//                return nodeB;
//            if (nodeB == null || nodeB.ActionHandler == null)
//                return nodeA;
//            if (nodeA.Cost > nodeB.Cost)
//            {
//                return nodeB;
//            }
//            else if (nodeA.Cost < nodeB.Cost)
//            {
//                return nodeA;
//            }
//            else
//            {
//                if (nodeA.ActionHandler.Action.Priority > nodeB.ActionHandler.Action.Priority)
//                {
//                    return nodeA;
//                }
//                else
//                {
//                    return nodeB;
//                }
//            }
//        }
    }
}
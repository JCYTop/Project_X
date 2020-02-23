/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Planner
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/23 14:20:33
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace GOAP
{
    public class Planner<TAction, TGoal> : IPlanner<TAction, TGoal>
    {
        private IAgent<TAction, TGoal> _agent;

        public Planner(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
        }

        public Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal)
        {
            var plan = new Queue<IActionHandler<TAction>>();
            if (goal == null)
                return plan;
            var currentNode = Plan(goal);
            if (currentNode == null)
            {
                var label = _agent.ActionManager.GetDefaultActionLabel();
                plan.Enqueue(_agent.ActionManager.GetHandler(label));
                DebugMsg.LogError("当前节点为空，设置当前动作为默认动作");
                return plan;
            }

            while (currentNode.ID != TreeNode<TAction>.DEFAULT_ID)
            {
                plan.Enqueue(currentNode.ActionHandler);
                currentNode = currentNode.ParentNode;
            }

            DebugMsg.Log("计划完成");
            return plan;
        }

        private TreeNode<TAction> Plan(IGoal<TGoal> goal)
        {
            var tree = new Tree<TAction>();
            var topNode = CreateTopNode(tree, goal);
            var currentNode = topNode;
            while (!IsEnd(currentNode))
            {
            }

            //TODO 暂停一下
            return null;
        }

        private bool IsEnd(TreeNode<TAction> currentNode)
        {
            if (currentNode == null)
                return true;
            if (GetStateDifferectNum(currentNode) == 0)
            {
                return true;
            }

            return false;
        }


        private int GetStateDifferectNum(TreeNode<TAction> currentNode)
        {
            return currentNode.CurrentState.GetValueDifference(currentNode.GoalState).Count;
        }

        private TreeNode<TAction> CreateTopNode(Tree<TAction> tree, IGoal<TGoal> goal)
        {
            var topNode = tree.CreateTopNode();
            topNode.GoalState.Set(goal.GetEffects());
            var keys = topNode.CurrentState.GetNotExistKeys(topNode.GoalState);
            foreach (var key in keys)
            {
                topNode.CurrentState.Set(key, _agent.AgentState.Get(key));
            }

            return topNode;
        }
    }
}
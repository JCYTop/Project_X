/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalManager
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 23:23:39
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;
using System.Linq;

namespace GOAP
{
    public abstract class GoalManager<TAction, TGoal> : IGoalManager<TGoal>
        where TAction : struct
        where TGoal : struct
    {
        private Dictionary<TGoal, IGoal<TGoal>> _goalsDic;
        private List<IGoal<TGoal>> _activeGoal;
        private IAgent<TAction, TGoal> _agent;
        public IGoal<TGoal> Current { get; private set; }

        public GoalManager(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
            _goalsDic = new Dictionary<TGoal, IGoal<TGoal>>();
        }

        protected abstract void InitGoals();

        public void AddGoal(TGoal label)
        {
            var goal = _agent.Map.GetGoal(label);
            if (goal != null)
            {
                _goalsDic.Add(label, goal);
                goal.AddGoalActivateListener((currentGoal) =>
                {
                    if (!_activeGoal.Contains(currentGoal))
                        _activeGoal.Add(currentGoal);
                });
                goal.AddGoalInActivateListener((currentGoal) =>
                {
                    if (_activeGoal.Contains(currentGoal))
                        _activeGoal.Add(currentGoal);
                });
            }
        }

        public void RemoveGoal(TGoal label)
        {
            _goalsDic.Remove(label);
        }

        public IGoal<TGoal> GetGoal(TGoal label)
        {
            if (_goalsDic.ContainsKey(label))
            {
                return _goalsDic[label];
            }

            DebugMsg.LogError("当前代理未初始化");
            return null;
        }

        public IGoal<TGoal> FindGoal()
        {
            _activeGoal = _activeGoal.OrderByDescending(u => u.GetPriority()).ToList();
            if (_activeGoal.Count > 0)
            {
                return _activeGoal[0];
            }
            else
            {
                return null;
            }
        }

        public void UpdateData()
        {
            UpdateGoals();
            UpdateCurrentGoal();
        }

        private void UpdateGoals()
        {
            foreach (var goal in _goalsDic)
            {
                goal.Value.UpdateData();
            }
        }

        private void UpdateCurrentGoal()
        {
            Current = FindGoal();
            if (Current == null)
            {
                DebugMsg.LogError("当前目标为空");
            }
        }
    }
}
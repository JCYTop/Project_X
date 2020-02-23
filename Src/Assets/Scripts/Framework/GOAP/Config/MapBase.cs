/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     MapBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 14:48:56
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;
using System.Diagnostics;

namespace GOAP
{
    public abstract class MapBase<TAction, TGoal> : IMap<TAction, TGoal>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _actionHandlerDic;
        private Dictionary<TGoal, IGoal<TGoal>> _goalDic;
        private Dictionary<string, object> _gameDataDic;

        public MapBase()
        {
            _actionHandlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _goalDic = new Dictionary<TGoal, IGoal<TGoal>>();
            _gameDataDic = new Dictionary<string, object>();
            InitActionMap();
            InitGoalMap();
            InitGameData();
        }

        public IActionHandler<TAction> GetActionHandler(TAction actionLabel)
        {
            _actionHandlerDic.TryGetValue(actionLabel, out var handler);
            if (handler == null)
                DebugMsg.LogError("当前无法找到对应的IActionHandler，标签名称为： " + actionLabel);

            return handler;
        }

        public IGoal<TGoal> GetGoal(TGoal label)
        {
            _goalDic.TryGetValue(label, out var goal);
            if (goal == null)
                DebugMsg.LogError("目标映射中未找到目标对象");
            return goal;
        }

        public void SetGameData<Tkey>(Tkey key, object data)
        {
            _gameDataDic.Add(key.ToString(), data);
        }

        public object GetGameData<Tkey>(Tkey key)
        {
            if (_gameDataDic.ContainsKey(key.ToString()))
            {
                return _gameDataDic[key.ToString()];
            }
            else
            {
                DebugMsg.LogError("缓存中未包含对应数据");
                return null;
            }
        }

        protected abstract void InitActionMap();
        protected abstract void InitGoalMap();
        protected abstract void InitGameData();

        protected void AddAction(IActionHandler<TAction> handler)
        {
            if (!_actionHandlerDic.ContainsKey(handler.Label))
            {
                _actionHandlerDic.Add(handler.Label, handler);
            }
            else
            {
                DebugMsg.LogError("发现重复标签");
            }
        }

        protected void AddGoal(IGoal<TGoal> goal)
        {
            if (!_goalDic.ContainsKey(goal.Label))
            {
                _goalDic.Add(goal.Label, goal);
            }
            else
            {
                DebugMsg.LogError("发现重复key");
            }
        }
    }
}
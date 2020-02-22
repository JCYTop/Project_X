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

namespace GOAP
{
    public abstract class MapBase<TAction> : IMap<TAction>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _actionHandlerDic;

        public MapBase()
        {
            _actionHandlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            InitActionMap();
        }

        public IActionHandler<TAction> GetActionHandler(TAction actionLabel)
        {
            _actionHandlerDic.TryGetValue(actionLabel, out var handler);
            if (handler == null)
                DebugMsg.LogError("当前无法找到对应的IActionHandler，标签名称为： " + actionLabel);

            return handler;
        }

        protected abstract void InitActionMap();

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
    }
}
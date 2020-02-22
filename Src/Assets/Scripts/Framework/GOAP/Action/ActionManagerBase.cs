/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionManagerBAse
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 14:38:51
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace GOAP
{
    public abstract class ActionManagerBase<TAction> : IActionManager<TAction>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _handlerDic;
        private IFSM<TAction> _fsm;

        public ActionManagerBase()
        {
            _handlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _fsm = new FSM<TAction>();
        }

        public void AddHandler(TAction label)
        {
//            _handlerDic.Add(label,);
        }

        public void RemoveHandle(TAction label)
        {
            throw new NotImplementedException();
        }

        public IActionHandler<TAction> GetHandler(TAction label)
        {
            throw new NotImplementedException();
        }

        public void UpdateData()
        {
            throw new NotImplementedException();
        }

        public void FrameFun()
        {
            throw new NotImplementedException();
        }

        public void ChangeCurrentAction(TAction label)
        {
            throw new NotImplementedException();
        }

        public void AddActionCompleteListener(Action complete)
        {
            throw new NotImplementedException();
        }
    }
}
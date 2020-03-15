/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     StateMgr
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/06 16:30:54
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace Framework.GOAP
{
    public abstract class StateMgr<TStateBase> : IStateMgr
    {
        /// <summary>
        /// 静态默认载入的State的Event
        /// </summary>
        public virtual string StartStateEvent => "Idle";

        public abstract SortedList<StateTag, TStateBase> StateSortList { get; }
        public abstract StateTag CurrStateTag { get; }
        public abstract IState CurrState { get; }

        /// <summary>
        /// 设置当前的进行状态
        /// </summary>
        public abstract void SetCurrActivity(StateTag tag);
    }
}
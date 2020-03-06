/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     StateManagerBase
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

namespace GOAP
{
    public abstract class StateManagerBase : IStateManager
    {
        public const string StartStateEvent = "Idle";
        public IState CurrState { get; }
        public abstract SortedList<TStateTag, AIStateBase<TContext, TConfig>> GetStateList<TStateTag, TContext, TConfig>()
            where TContext : class, IContext;
    }
}
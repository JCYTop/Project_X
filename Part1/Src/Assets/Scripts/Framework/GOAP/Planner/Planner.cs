/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Planner
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/17 23:06:56
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace Framework.GOAP
{
    /// <summary>
    /// 具体的执行计算排序类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    /// <typeparam name="TGoal"></typeparam>
    public abstract class Planner<TAction, TGoal> : IPlanner<TAction, TGoal>
    {
        protected IAgent<TAction, TGoal> agent;

        public Planner(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
        }

        public abstract LinkedList<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal);
    }
}
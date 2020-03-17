/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IPlanner
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 23:09:46
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace Framework.GOAP
{
    public interface IPlanner<TAction, TGoal>
    {
        /// <summary>
        /// 产生动作序列
        /// TODO 可打断的
        /// TODO 可重新生成
        /// TODO 可插入可删除
        /// </summary>
        LinkedList<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal);
    }
}
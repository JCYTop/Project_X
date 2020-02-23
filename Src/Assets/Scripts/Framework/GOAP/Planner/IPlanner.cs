/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IPlanner
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/23 14:18:02
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace GOAP
{
    public interface IPlanner<TAction, TGoal>
    {
        Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal);
    }
}
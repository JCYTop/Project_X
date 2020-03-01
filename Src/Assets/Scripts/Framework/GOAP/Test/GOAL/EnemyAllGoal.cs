/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     EnemyAllGoal
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/02/29 21:12:59
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace GOAP
{
    /// <summary>
    /// 敌人的所有的目标
    /// 每一个目标Enum对应一个目标信息设置类
    /// </summary>
    public class EnemyAllGoal : GoalConfig<GoalTag, GoalConfigElementTag>
    {
        public List<EnemyAllGoalUnit> sss = new List<EnemyAllGoalUnit>();

        public override GoalConfig<GoalTag, GoalConfigElementTag> Init()
        {
            throw new System.NotImplementedException();
        }
    }

    [Serializable]
    public class EnemyAllGoalUnit
    {
        /// <summary>
        /// 具体的目标标签
        /// </summary>
        public GoalTag Tag;

        public EnemyGoalConfigUnit Unit;
    }
}
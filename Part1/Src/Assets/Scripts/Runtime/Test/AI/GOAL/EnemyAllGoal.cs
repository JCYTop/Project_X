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
using UnityEngine;

namespace Framework.GOAP
{
    /// <summary>
    /// 敌人的所有的目标
    /// 每一个目标Enum对应一个目标信息设置类
    /// </summary>
    public class EnemyAllGoal : GoalConfig<GoalTag>
    {
        public List<EnemyAllGoalUnit> allGoal = new List<EnemyAllGoalUnit>();

        public override SortedList<GoalTag, GoalConfigUnit> Init()
        {
            var goalSort = new SortedList<GoalTag, GoalConfigUnit>();
            allGoal.ForEach((goal) =>
            {
                goal.File.Priority = goal.Priority;
                goal.File.Init();
                goalSort.Add(goal.tag, goal.File.GetConfigUnit);
            });
            LogTool.Log($" --- {this.name} , Goal数据已经加载完成 --->>> 共计${allGoal.Count}个", LogEnum.AssetLog);
            return goalSort;
        }
    }

    [Serializable]
    public class EnemyAllGoalUnit
    {
        [Space(5), Rename("标签")] public GoalTag tag;

        [Space(5), Rename("权重"), SerializeField]
        public int Priority;

        [Space(5), Rename("配置文件")] public EnemyGoalConfigUnit File;
    }
}
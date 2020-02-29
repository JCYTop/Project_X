/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalConfig
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/02/29 20:14:14
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    /// <summary>
    /// 配置文件基类
    /// </summary>
    /// <typeparam name="T1">GoalBaseTag标签使用</typeparam>
    [Serializable]
    public abstract class GoalConfig<T1, T2> : ScriptableObject
    {
        protected SortedList<T1, Dictionary<T2, IConfigElementBase>> goalConfigSet = new SortedList<T1, Dictionary<T2, IConfigElementBase>>();

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public abstract GoalConfig<T1, T2> Init();
    }

    //TODO T 和 GoalBaseTag 对应
    //TODO Value 是每个T对应的目标信息配置文件
    //TODO 配置文件是针对GOAL每个配置的
    //TODO 系统读取配置文件然后初始化IGoal接口
    //TODO 
}
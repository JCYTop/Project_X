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
    /// T1 和 GoalTag 对应
    /// </summary>
    /// <typeparam name="T1">GoalTag标签使用</typeparam>
    /// <typeparam name="T2">GoalConfigElementTag标签使用</typeparam>
    [Serializable]
    public abstract class GoalConfig<T1, T2> : ScriptableObject
    {
        protected SortedList<T1, GoalConfigUnit<T2>> goalConfigSet = new SortedList<T1, GoalConfigUnit<T2>>();

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public abstract SortedList<T1, GoalConfigUnit<T2>> Init();
    }
}
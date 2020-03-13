/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalConfigUnit
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 17:14:46
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
    /// 配置文件元素基类
    /// </summary>
    /// <typeparam name="T">GoalConfigElementTag标签使用</typeparam>
    [Serializable]
    public abstract class GoalConfigUnit<T> : UnityEngine.ScriptableObject
    {
        [Rename("权重")] public int Priority;
        public List<CondtionAssembly> Condition;
        public List<CondtionAssembly> Effets;
        public SortedList<T, object> goalConfigUnitSet = new SortedList<T, object>();

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public abstract GoalConfigUnit<T> Init();

        protected void ADD(T tag, object obj)
        {
            goalConfigUnitSet.AddSortListElement(tag, obj);
        }
    }

    /// <summary>
    /// 可以以后继承
    /// </summary>
    public enum GoalElementTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 权重
        /// </summary>
        Priority = 1,

        /// <summary>
        /// 初始化影响
        /// </summary>
        Effects = 2,

        /// <summary>
        /// 激活条件
        /// </summary>
        Conditon = 3,

        #endregion
    }
}
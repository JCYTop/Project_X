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
    public abstract class GoalConfigUnit : UnityEngine.ScriptableObject, IConfigUnit<GoalConfigUnit, GoalElementTag>
    {
        private SortedList<GoalElementTag, object> goalConfigUnitSet;
        [SerializeField] private List<CondtionAssembly> Condition;
        [SerializeField] private List<CondtionAssembly> Effets;
        public GoalConfigUnit GetConfigUnit => this;

        public SortedList<GoalElementTag, object> ConfigUnitSet
        {
            get
            {
                if (goalConfigUnitSet == null)
                {
                    goalConfigUnitSet = new SortedList<GoalElementTag, object>();
                }

                return goalConfigUnitSet;
            }
        }

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public void Init()
        {
            ConfigUnitSet.Add(GoalElementTag.Conditon, Condition);
            ConfigUnitSet.Add(GoalElementTag.Effects, Effets);
            LogTool.Log($"{this.name} , GoalConfigUnit数据已经加载完成", LogEnum.AssetLog);
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
        /// 初始化影响
        /// </summary>
        Effects = 1,

        /// <summary>
        /// 激活条件
        /// </summary>
        Conditon = 2,

        #endregion
    }
}
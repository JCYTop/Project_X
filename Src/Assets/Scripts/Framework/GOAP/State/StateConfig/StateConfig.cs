/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     StateConfig
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 23:57:30
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
    /// 配置文件基类
    /// </summary>
    [Serializable]
    public abstract class StateConfig : UnityEngine.ScriptableObject, IConfigUnit<StateConfig, AIStateElementTag>
    {
        private SortedList<AIStateElementTag, object> configUnitSet;
        [Rename("标签")] public StateTag Tag;
        public StateConfig GetConfigUnit => this;

        public SortedList<AIStateElementTag, object> ConfigUnitSet
        {
            get
            {
                if (configUnitSet == null)
                {
                    configUnitSet = new SortedList<AIStateElementTag, object>();
                }

                return configUnitSet;
            }
        }

        public void Init()
        {
        }
    }

    /// <summary>
    /// IConfigElementBase标签
    /// IConfigElementBase配置文件标签
    /// 每个标签对应这当前属性的类
    /// 方便通过标签快速查找工具类
    /// 可以以后继承
    /// </summary>
    public enum AIStateElementTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        #endregion

        #region Target目标 200~399

        /// <summary>
        /// 是否存在目标
        /// 非战斗目标
        /// </summary>
        Normal_Target = 200,

        /// <summary>
        /// 是否离目标过远
        /// 是否离非战斗目标过远
        /// </summary>
        Far_Normal_Target,

        #endregion
    }

    /// <summary>
    /// 存在进行判断
    /// 不存在忽略判断
    /// 应该专门写一个外部环境类保存时事计算参数 && 保存基础数值
    /// </summary>
    [Serializable]
    [Obsolete]
    public class StateConfigUnitsss
    {
        [Rename("标签")] public AIStateElementTag ElementTag;
        [Rename("标志位")] public bool IsRight = true;

        public StateConfigUnitsss()
        {
        }

        public StateConfigUnitsss(AIStateElementTag elementTag, bool right)
        {
            this.ElementTag = elementTag;
            this.IsRight = right;
        }
    }
}
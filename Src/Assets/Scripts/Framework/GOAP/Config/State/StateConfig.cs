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

        public virtual void Init()
        {
            //TODO  添加一些State的特性
        }
    }

    /// <summary>
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
    }
}
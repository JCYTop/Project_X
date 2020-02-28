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

namespace GOAP
{
    /// <summary>
    /// 配置文件基类
    /// </summary>
    [Serializable]
    public abstract class StateConfig : ScriptableObject
    {
        protected SortedList<AIStateConfigElement, IStateConfigElementBase> stateConfigSet = new SortedList<AIStateConfigElement, IStateConfigElementBase>();

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public abstract StateConfig Init();
    }

    /// <summary>
    /// 状态参数
    /// 状态配置文件标签
    /// 每个标签对应这当前属性的状态类
    /// 方便通过标签快速查找工具类
    /// </summary>
    public enum AIStateConfigElement
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        #region Common 100~199

        Bleed = 100,

        #endregion
    }
}
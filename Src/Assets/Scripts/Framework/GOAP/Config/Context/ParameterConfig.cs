/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ParameterConfig
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 16:27:43
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
    /// AI参数配置接口
    /// </summary>
    [Serializable]
    public class ParameterConfig : UnityEngine.ScriptableObject
    {
        public ParameterUnit[] Array;
    }

    /// <summary>
    /// 配置文件单元
    /// 某些装备也可以进行挂载
    /// </summary>
    [Serializable]
    public class ParameterUnit
    {
        /// <summary>
        /// 标签
        /// </summary>
        [Rename("标签")] public ParameterTag Tag;

        /// <summary>
        /// 值范围
        /// </summary>
        [Rename("值范围")] public Vector2 DynamicRange;

        /// <summary>
        /// 值
        /// </summary>
        [Rename("值")] public float Value;

        public ParameterUnit()
        {
        }

        public ParameterUnit(ParameterTag tag, float value)
        {
            this.Tag = tag;
            this.Value = value;
        }
    }

    public enum ParameterTag
    {
        #region Common 0~199 

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 血量
        /// </summary>
        Bleed_Value,

        /// <summary>
        /// 能量
        /// </summary>
        Energy_Value,

        /// <summary>
        /// 愤怒值
        /// </summary>
        Anger_Value,

        /// <summary>
        /// 默认警戒距离
        /// </summary>
        Alert_Dis,

        /// <summary>
        /// 默认攻击距离
        /// </summary>
        Attack_Dis,

        /// <summary>
        /// 接近目标的最小举例
        /// </summary>
        Near_Dis,

        #endregion
    }
}
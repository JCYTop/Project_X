/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ParameterUnit
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 23:03:04
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Framework.GOAP
{
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
        public ParameterTag Tag;

        /// <summary>
        /// 值的范围
        /// </summary>
        public Vector2 DynamicRange;

        /// <summary>
        /// 值
        /// </summary>
        public float Value;

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
        /// <summary>
        /// 默认
        /// </summary>
        Default,

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
        Attack_Dis
    }
}
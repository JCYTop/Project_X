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
using UnityEngine;

namespace Framework.GOAP
{
    [Serializable]
    public class ParameterUnit
    {
        [Header("标签")] public ParameterTag Tag;
        [Header("值")] public int Value;

        public ParameterUnit()
        {
        }

        public ParameterUnit(ParameterTag tag, int value)
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
        Anger_Value
    }
}
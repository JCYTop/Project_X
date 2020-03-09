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

namespace GOAP
{
    /// <summary>
    /// AI参数配置接口
    /// </summary>
    [Serializable]
    public class ParameterConfig : ScriptableObject
    {
        public ParameterUnit[] Array;
      }

    [Serializable]
    public class ParameterUnit
    {
        [Header("标签")] public ParameterTag Tag;
        [Header("值")] public int Value;
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
        Bleed,

        /// <summary>
        /// 能量
        /// </summary>
        Enemgy,
    }
}
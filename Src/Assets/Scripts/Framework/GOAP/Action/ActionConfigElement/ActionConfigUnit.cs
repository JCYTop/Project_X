/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionConfigUnit
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 18:51:07
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
    /// 配置文件元素基类
    /// </summary>
    /// <typeparam name="T">ActionConfigElementTag 标签</typeparam>
    [Serializable]
    public abstract class ActionConfigUnit<T> : ScriptableObject
    {
        public ActionUnityGroup ActionUnityGroup;
        public SortedList<T, IConfigElement> ActionConfigUnitSet = new SortedList<T, IConfigElement>();

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public abstract ActionConfigUnit<T> Init();
    }

    /// <summary>
    /// 关联Unity中的信息
    /// Playable重要类
    /// </summary>
    [Serializable]
    public class ActionUnityGroup
    {
        public AnimationClip[] Animation;
        public AudioClip[] AudioClip;
        public GameObject[] ParticleEffects;
    }
}
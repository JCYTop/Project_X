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

namespace Framework.GOAP
{
    /// <summary>
    /// 配置文件元素基类
    /// </summary>
    /// <typeparam name="T">ActionConfigElementTag 标签</typeparam>
    [Serializable]
    public abstract class ActionConfigUnit<T> : UnityEngine.ScriptableObject
    {
        [Rename("文件组")] public ActionUnityGroup ActionUnityGroup;
        [Rename("Handler标签")] public ActionHanderTag HanderTag;
        [Rename("权重")] public int Priority;
        [Rename("是否可打断")] public bool IsInterruptible = false;
        [Rename("消耗")] public int Cost;
        public List<StateAssembly> Preconditions;
        public List<StateAssembly> Effects;
        public SortedList<T, object> ActionConfigUnitSet = new SortedList<T, object>();

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public abstract ActionConfigUnit<T> Init();
    }

    /// <summary>
    /// 关联Unity中的信息
    /// Playable重要类
    /// 以后重要扩展
    /// </summary>
    [Serializable]
    public class ActionUnityGroup
    {
        public AnimationClip[] Animation;
        public AudioClip[] AudioClip;
        public GameObject[] ParticleEffects;
    }
}
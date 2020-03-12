/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionConfig
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 18:40:42
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
    /// T1 和 ActionTag 对应
    /// </summary>
    /// <typeparam name="T1">ActionTag 标签</typeparam>
    /// <typeparam name="T2">ActionConfigElementTag 标签</typeparam>
    [Serializable]
    public abstract class ActionConfig<T1, T2> : UnityEngine.ScriptableObject
    {
        protected SortedList<T1, ActionConfigUnit<T2>> actionConfigSet = new SortedList<T1, ActionConfigUnit<T2>>();

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public abstract SortedList<T1, ActionConfigUnit<T2>> Init();
    }
}
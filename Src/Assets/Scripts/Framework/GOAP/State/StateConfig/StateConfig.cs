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

namespace Framework.GOAP
{
    /// <summary>
    /// 配置文件基类
    /// </summary>
    [Serializable]
    public abstract class StateConfig<T> : UnityEngine.ScriptableObject
    {
        [Rename("状态标签")] public T Tag;
        public List<StateAssembly> StateElement;
    }
}
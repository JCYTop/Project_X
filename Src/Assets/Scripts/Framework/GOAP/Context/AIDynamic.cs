/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AIDynamic
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/10 17:36:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;
using Framework.EventDispatcher;

namespace Framework.GOAP
{
    /// <summary>
    /// 外部动态变量
    /// 外部关联
    /// 外部对其主要修改这里的数据
    /// 还可能有标签类信息(队伍标签)
    /// </summary>
    public abstract class AIDynamic : MonoEventEmitter
    {
        public Dictionary<DynamicObjTag, object> DynamicDic = new Dictionary<DynamicObjTag, object>(1 << 5);

        private void Awake()
        {
            Init();
        }

        /// <summary>
        /// 就是初始化
        /// </summary>
        public abstract void Init();
    }

    public static class AIDynamicExtend
    {
        /// <summary>
        /// 直接获取数值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T PushDynamicData<T>(this AIDynamic dynamic, DynamicObjTag tag)
        {
            return (T) dynamic.DynamicDic.GetDictionaryValue(tag);
        }
    }

    /// <summary>
    /// 为了统一拿数据的结构
    /// </summary>
    public enum DynamicObjTag
    {
        Default,

        /// <summary>
        /// 目标
        /// 返回List<GameObject>
        /// </summary>
        Targets,
    }
}
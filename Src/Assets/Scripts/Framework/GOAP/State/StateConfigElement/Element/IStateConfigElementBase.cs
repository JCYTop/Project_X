/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IStateConfigElementBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/26 22:37:19
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    public interface IStateConfigElementBase
    {
        string TypeName { set; get; }
    }

    public abstract class StateConfigElement<T> : IStateConfigElementBase
    {
        public abstract T Data { get; set; }

        public StateConfigElement(T value)
        {
        }

        /// <summary>
        /// 子类的类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 获取当前存入的值
        /// </summary>
        /// <returns></returns>
        public abstract T GetData();
    }

    public static class IStateConfigElementBaseExtend
    {
        /// <summary>
        /// 转换成指定类型的IStateConfigElementBase
        /// </summary>
        /// <param name="configElement">IStateConfigElementBase类型</param>
        /// <typeparam name="T">指定类型</typeparam>
        /// <returns>返回指定类型T</returns>
        public static T CastStateConfigEle<T>(this IStateConfigElementBase configElement)
        {
            try
            {
                return (T) configElement;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
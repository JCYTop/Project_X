/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IConfigElementBase
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
    /// <summary>
    /// 序列化文件配置基础接口
    /// 所有需要配置序列化问价都继承这里
    /// </summary>
    public interface IConfigElementBase
    {
        string TypeName { set; get; }
    }

    public abstract class ConfigElement<T> : IConfigElementBase
    {
        public abstract T Data { get; set; }

        public ConfigElement(T value)
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

    public static class IConfigElementBaseExtend
    {
        /// <summary>
        /// 转换成指定类型的IStateConfigElementBase
        /// </summary>
        /// <param name="configElement">IStateConfigElementBase类型</param>
        /// <typeparam name="T">指定类型</typeparam>
        /// <returns>返回指定类型T</returns>
        public static T CastStateConfigEle<T>(this IConfigElementBase configElement)
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

    /// <summary>
    /// IConfigElementBase标签
    /// IConfigElementBase配置文件标签
    /// 每个标签对应这当前属性的类
    /// 方便通过标签快速查找工具类
    /// </summary>
    public enum AIStateConfigElementTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        #endregion

        /// <summary>
        /// 血量标记元素
        /// </summary>
        Bleed = 200,
    }

    public enum GoalConfigElementTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 权重
        /// </summary>
        Priority = 1,

        /// <summary>
        /// 初始化影响
        /// </summary>
        Effects = 2,

        /// <summary>
        /// 激活条件
        /// </summary>
        ActiveConditon = 3,

        #endregion
    }

    public enum ActionConfigElementTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 权重
        /// </summary>
        Priority = 1,

        #endregion
    }
}
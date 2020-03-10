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

namespace Framework.GOAP
{
    /// <summary>
    /// 序列化文件配置基础接口
    /// 所有需要配置序列化问价都继承这里
    /// </summary>
    public interface IConfigElement
    {
    }

    public abstract class ConfigElementBase<T> : IConfigElement
    {
        /// <summary>
        /// 获取当前存入的值
        /// </summary>
        public T Data { get; private set; }

        public ConfigElementBase(T value)
        {
            this.Data = value;
        }
    }

    public static class IConfigElementExtend
    {
        /// <summary>
        /// 转换成指定类型的IStateConfigElementBase
        /// </summary>
        /// <param name="configElement">IStateConfigElementBase类型</param>
        /// <typeparam name="T">指定类型</typeparam>
        /// <returns>返回指定类型T</returns>
        public static T CastStateConfigEle<T>(this IConfigElement configElement)
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

    #region State标签

    /// <summary>
    /// IConfigElementBase标签
    /// IConfigElementBase配置文件标签
    /// 每个标签对应这当前属性的类
    /// 方便通过标签快速查找工具类
    /// 可以以后继承
    /// </summary>
    public enum AIStateElementTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        #endregion

        #region Target目标 200~399

        /// <summary>
        /// 是否存在目标
        /// 非战斗目标
        /// </summary>
        Normal_Targets = 200,

        /// <summary>
        /// 是否离目标过远
        /// 是否离非战斗目标过远
        /// </summary>
        Far_Normal_Target,

        #endregion
    }

    #endregion

    #region GOAL标签

    /// <summary>
    /// 可以以后继承
    /// </summary>
    public enum GoalElementTag
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

    #endregion

    #region Action标签

    public enum ActionElementTag
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
        /// 是否可打断
        /// </summary>
        Interruptible = 2,

        /// <summary>
        /// 动作花费
        /// </summary>
        Cost = 3,

        #endregion
    }

    public enum EnemyActionElementTag
    {
        Default = ActionElementTag.Default,
        Priority = ActionElementTag.Priority,
        Interruptible = ActionElementTag.Interruptible,
        Cost = ActionElementTag.Cost,
    }

    #endregion
}
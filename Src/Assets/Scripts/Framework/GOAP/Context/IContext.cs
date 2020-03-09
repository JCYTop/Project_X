/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IContext
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/25 22:52:55
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using JetBrains.Annotations;

namespace Framework.GOAP
{
    /// <summary>
    /// 与Mono关联的环境接口
    /// 所有Mono数据从接口获取
    /// 主要是一些组件信息
    /// 提供给IAgent数据使用
    /// 属于数据类
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// 基础初始化
        /// </summary>
        void Init();
    }

    /// <summary>
    /// IContext扩展方法
    /// </summary>
    public static class IContextExtend
    {
        /// <summary>
        /// 获取环境指定类型
        /// </summary>
        /// <param name="context"></param>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public static TContext GetContext<TContext>([NotNull] this IContext context)
            where TContext : class, IContext
        {
            try
            {
                return (TContext) context;
            }
            catch (Exception e)
            {
                LogTool.LogException(e);
                throw;
            }
        }
    }
}
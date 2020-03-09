/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IStateManager
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/06 14:58:29
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace Framework.GOAP
{
    /// <summary>
    /// 主要用于Agent中存储信息使用
    /// 记录当前状态使用
    /// </summary>
    public interface IStateManager
    {
        string StartStateEvent { get; }
        IState CurrState { get; }
    }

    public static class IStateManagerExtend
    {
        /// <summary>
        /// 获取当前StateMgr的指定类型
        /// </summary>
        /// <param name="stateMgr">stateMgr类型</param>
        /// <typeparam name="T">stateMgr类型</typeparam>
        /// <returns></returns>
        public static T GetStateMgr<T>(this IStateManager stateMgr) where T : class, IStateManager
        {
            try
            {
                return stateMgr as T;
            }
            catch (Exception e)
            {
                LogTool.LogException(e);
                throw;
            }
        }
    }
}
/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IAgent
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 23:09:13
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 集合类
    /// Mono数据从这里拿取
    /// State数据从这里拿取
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public interface IAgent<TAction>
    {
        /// <summary>
        /// 环境数据
        /// </summary>
        IContext Context { get; }

        /// <summary>
        /// 状态数据
        /// </summary>
        IState AgentState { get; }

        /// <summary>
        /// 注册事件
        /// 用于Agent事件
        /// </summary>
        void RegiestEvent();

        /// <summary>
        /// 注销事件
        /// 用于Agent事件
        /// </summary>
        void UnRegiestEvent();
    }
}
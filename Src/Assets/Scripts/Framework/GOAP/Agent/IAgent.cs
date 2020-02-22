/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IAgent
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/20 23:41:31
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 代理集合
    /// 各个功能模块的整合调用
    /// </summary>
    public interface IAgent<TAction,TGoal>
    {
        IState AgentState { get; }
        IMap<TAction,TGoal> Map { get; }
        void UdpateData();
        void FrameFun();
    }
}
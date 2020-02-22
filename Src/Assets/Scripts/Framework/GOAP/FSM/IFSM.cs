/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IFSM
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 14:15:07
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 处理状态切换
    /// </summary>
    /// <typeparam name="TLabel"></typeparam>
    public interface IFSM<TLabel>
    {
        TLabel CurrentState { get; }
        TLabel PreviousState { get; }
        void AddState(TLabel label, IFSMState<TLabel> state);
        void ChangeState(TLabel newStates);
        void FrameFun();
    }

    public interface IFSMState<TLabel>
    {
        TLabel Label { get; }
        void Enter();
        void Excute();
        void Exit();
    }
}
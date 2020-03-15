/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IGoalManager
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/02/29 17:38:38
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace Framework.GOAP
{
    /// <summary>
    /// IGoalManager接口
    /// </summary>
    /// <typeparam name="TGoal">由类传入string</typeparam>
    public interface IGoalMgr<TGoal>
    {
        /// <summary>
        /// 当前执行的目标
        /// </summary>
        IGoal<TGoal> CurrentGoal { get; }

        /// <summary>
        /// 根据标签获取一个目标
        /// </summary>
        /// <param name="goalLabel"></param>
        /// <returns></returns>
        IGoal<TGoal> GetGoal(TGoal goalLabel);

        /// <summary>
        /// 添加一个目标
        /// </summary>
        /// <param name="goal"></param>
        void AddGoal(IGoal<TGoal> goal);

        /// <summary>
        /// 移除一个目标
        /// </summary>
        /// <param name="goalLabel"></param>
        void RemoveGoal(TGoal goalLabel);

        /// <summary>
        /// 找到合适的可执行的当前目标
        /// </summary>
        /// <returns></returns>
        IGoal<TGoal> FindGoal();

        /// <summary>
        /// 更新数据
        /// </summary>
        void UpdateData();

        /// <summary>
        /// 获取相对应的GoalMgr
        /// </summary>
        /// <typeparam name="TGoalMgr"></typeparam>
        /// <returns></returns>
        TGoalMgr GetGoalMgr<TGoalMgr>() where TGoalMgr : class;
    }
}
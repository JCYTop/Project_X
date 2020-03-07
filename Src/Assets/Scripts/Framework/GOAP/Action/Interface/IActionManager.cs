/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IActionManager
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 22:29:29
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace GOAP
{
    public interface IActionManager<TAction>
    {
        /// <summary>
        /// 当前是否在执行动的标志位
        /// 用于避免动作已经结束，却还在执行帧函数的情况
        /// </summary>
        bool IsPerformAction { get; set; }

        /// <summary>
        /// 效果和动作的映射关系
        /// </summary>
        Dictionary<TAction, HashSet<IActionHandler<TAction>>> EffectsAndActionMap { get; }

        /// <summary>
        /// 获取默认动作的标签
        /// </summary>
        /// <returns></returns>
        TAction GetDefaultActionLabel();

        /// <summary>
        /// 添加处理类对象
        /// </summary>
        void AddActionHandler(TAction actionLabel);

        /// <summary>
        /// 移除处理类对象
        /// </summary>
        /// <param name="handler"></param>
        void RemoveHandler(TAction actionLabel);

        /// <summary>
        /// 获取处理类对象
        /// </summary>
        /// <param name="handler"></param>
        IActionHandler<TAction> GetHandler(TAction actionLabel);

        /// <summary>
        /// 改变当前执行的动作
        /// </summary>
        /// <param name="actionLabel"></param>
        void ExcuteNewState(TAction actionLabel);

        /// <summary>
        /// 添加动作完成的监听
        /// </summary>
        /// <param name="actionComplete"></param>
        void AddActionCompleteListener(Action<TAction> actionComplete);

        /// <summary>
        /// 帧函数
        /// </summary>
        void Update();

        /// <summary>
        /// 更新数据
        /// </summary>
        void UpdateData();
    }
}
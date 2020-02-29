/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/29 00:37:46
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using UnityEngine;

namespace GOAP
{
    /// <summary>
    /// 每一个具体的Action
    /// 需要到配置文件中去配置
    /// 配置文件是预制体形式
    /// </summary>
    /// <typeparam name="TAction">由类传入string</typeparam>
    [Serializable]
    public abstract class ActionBase<TAction> : ScriptableObject, IActionUnity, IAction<TAction>
    {
        public ActionUnityGroup ActionUnityGroup { get; }
        public abstract TAction Label { get; }
        public int Priority { get; }
        public int Cost { get; }

        public bool CanInterruptiblePlan { get; }

        //TODO 出现疑惑
        public IState PreConditions { get; }
        public IState Effects { get; }

        public virtual bool VerifyPreconditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
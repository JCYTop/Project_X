/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AIState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 23:51:07
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using JetBrains.Annotations;

namespace Framework.GOAP
{
    /// <summary>
    /// FSM中State的基类
    /// </summary>
    /// <typeparam name="TContext">Context具体类</typeparam>
    /// <typeparam name="TConfig">配置文件具体的类型</typeparam>
    [ActionCategory("AI.Base")]
    public abstract class AIState<TContext, TConfig> : FsmStateAction, IState where TContext : class, IContext
    {
        private Action onChange;
        public FsmObject Context;

        /// <summary>
        /// 配置文件ScriptableObject
        /// 需要预先配置并且拖拽
        /// </summary>
        public TConfig StateConfig;

        /// <summary>
        /// 获取关联的Context环境
        /// </summary>
        protected TContext GetContext => Context.Value as TContext;

        #region FSM

        public override void Awake()
        {
            base.Awake();
            AwakeState();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            EnterState();
            RegiestEvent();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            ExecuteState();
        }

        public override void OnExit()
        {
            base.OnExit();
            UnRegiestEvent();
            ExitState();
        }

        #endregion

        public abstract void AwakeState();
        public abstract void EnterState();
        public abstract void ExecuteState();
        public abstract void ExitState();
        public abstract TConfig GetData();

        public virtual void RegiestEvent()
        {
        }

        public virtual void UnRegiestEvent()
        {
        }

        public void AddStateChangeListener([NotNull] Action callback)
        {
            this.onChange = callback;
        }
    }
}
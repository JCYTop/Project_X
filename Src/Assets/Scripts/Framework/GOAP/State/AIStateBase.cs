/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AIStateBase
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

namespace GOAP
{
    /// <summary>
    /// FSM中State的基类
    /// </summary>
    /// <typeparam name="TContext">Context具体类</typeparam>
    /// <typeparam name="TConfig">配置文件具体的类型</typeparam>
    [ActionCategory("AI.Base")]
    public abstract class AIStateBase<TContext, TConfig> : FsmStateAction, IState
        where TContext : class, IContext
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
        public TContext GetContext => Context.Value as TContext;

        #region FSM

        public override void Awake()
        {
            base.Awake();
            Init();
            RegiestEvent();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Enter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Execute();
        }

        public override void OnExit()
        {
            base.OnExit();
            UnRegiestEvent();
            Exit();
        }

        #endregion

        public abstract void Init();
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
        public abstract void SetData(IState data);
        public abstract IState GetData();

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

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public IState InversionValue()
        {
            throw new NotImplementedException();
        }

        public IConfigElementBase GetSingleValue(AIStateConfigElementTag key)
        {
            throw new NotImplementedException();
        }

        public bool CompareKey(AIStateConfigElementTag key)
        {
            throw new NotImplementedException();
        }

        public ICollection<AIStateConfigElementTag> GetKeys()
        {
            throw new NotImplementedException();
        }

        public void Copy(IState otherState)
        {
            throw new NotImplementedException();
        }

        public bool ContainState(IState otherState)
        {
            throw new NotImplementedException();
        }

        public SortedList<AIStateConfigElementTag, Dictionary<IState, IConfigElementBase>> GetSameData(IState otherState)
        {
            throw new NotImplementedException();
        }

        public ICollection<AIStateConfigElementTag> GetValueDifferences(IState otherState)
        {
            throw new NotImplementedException();
        }

        public ICollection<AIStateConfigElementTag> GetNotExistKeys(IState otherState)
        {
            throw new NotImplementedException();
        }
    }
}
/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AIContextBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/25 23:11:25
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using Framework.Base;
using Framework.EventDispatcher;
using UnityEngine;

namespace Framework.GOAP
{
    /// <summary>
    /// 启动每一个单独的GOAP
    /// 附着场景物体类
    /// 场景中物体调整参数类
    /// 跟Mono有关的集合类
    /// </summary>
    [RequireComponent(typeof(PlayMakerFSM))]
    public abstract class AIContextBase<T1, T2> : MonoEventEmitter, IContext, IGoalbalID
    {
        private PlayMakerFSM stateFsm;
        private AIParameter parameter;
        private AIDynamic dynamic;
        private AICondition condition;
        private int goalbalID = 0;
        [SerializeField] private FsmTemplate fsmTemplate;
        [SerializeField] private T1 actionConfig;
        [SerializeField] private T2 goalConfig;
        public PlayMakerFSM StateFsm => stateFsm;
        public AIParameter Parameter => parameter;
        public AIDynamic Dynamic => dynamic;
        public AICondition Condition => condition;
        public GameObject GameObject => this.gameObject;
        public T1 ActionConfig => actionConfig;
        public T2 GoalConfig => goalConfig;

        public int GoalbalID
        {
            get
            {
                if (goalbalID <= 0)
                {
                    goalbalID = this.GetComponentInParent<ObjectBase>().GlobalID;
                }

                return goalbalID;
            }
        }

        protected virtual void Awake()
        {
            stateFsm = this.GetComponent<PlayMakerFSM>();
            parameter = this.GetComponent<AIParameter>();
            dynamic = this.GetComponent<AIDynamic>();
            condition = this.GetComponent<AICondition>();
            Parameter.Init();
            Dynamic.Init();
        }

        protected virtual void Start()
        {
            Condition.Init();
            StateFsm.SetFsmTemplate(fsmTemplate);
        }
    }
}
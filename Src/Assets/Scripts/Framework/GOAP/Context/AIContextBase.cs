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

using Framework.EventDispatcher;
using UnityEngine;

namespace GOAP
{
    /// <summary>
    /// 启动每一个单独的GOAP
    /// 附着场景物体类
    /// 场景中物体调整参数类
    /// </summary>
    [RequireComponent(typeof(PlayMakerFSM))]
    public abstract class AIContextBase : MonoEventEmitter, IContext
    {
        public abstract PlayMakerFSM StateFsm { get; }

        private void Awake()
        {
            Init();
            InitActionConfig();
            InitGoalConfig();
        }

        private void Start()
        {
            InitStateConfig();
        }

        public abstract void Init();
        public abstract void InitActionConfig();
        public abstract void InitGoalConfig();
        public abstract void InitStateConfig();

        public TContext GetContext<TContext>()
            where TContext : class, IContext
        {
            return this as TContext;
        }

        public abstract IAgent<TAction, TGoal> Agent<TAction, TGoal>() where TAction : struct where TGoal : struct;
    }
}
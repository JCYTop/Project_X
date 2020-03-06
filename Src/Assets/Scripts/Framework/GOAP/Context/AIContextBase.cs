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

        /// <summary>
        /// 初始化动作配置信息 
        /// </summary>
        public abstract void InitActionConfig();

        /// <summary>
        /// 初始化目标配置信息
        /// </summary>
        public abstract void InitGoalConfig();

        /// <summary>
        /// 初始化状态信息
        /// </summary>
        public abstract void InitStateConfig();
    }
}
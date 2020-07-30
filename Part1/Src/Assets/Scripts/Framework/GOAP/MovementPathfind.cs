/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     MovementPathfind
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/16 15:36:23
 *Description:   
 *History:
 ----------------------------------
*/

using Framework.Base;
using Framework.Event;
using JetBrains.Annotations;
using Pathfinding;
using UnityEngine;

namespace Framework.GOAP
{
    public class MovementPathfind : MonoEventEmitter, IGoalbalID
    {
        private int goalbalID = 0;
        private Seeker seeker;

        /// <summary>
        /// 执行物体
        /// </summary>
        [SerializeField] private GameObject executeGo;

        #region 移动参数
                
        #endregion

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

        public Seeker Seeker
        {
            get
            {
                if (seeker == null)
                {
                    seeker.GetComponent<Seeker>();
                }

                return seeker;
            }
        }

        /// <summary>
        /// 主要自身调用
        /// </summary>
        /// <param name="target"></param>
        public void MovementUpdate([CanBeNull] GameObject target)
        {
            Seeker.SeekerGetPath(executeGo, target, (path) =>
            {
                if (!path.error)
                {
                    //TODO 进行移动
                }
                else
                {
                    LogTool.Log($"寻路启动失败 {path.errorLog}");
                }
            });
        }
    }
}
/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IActionUnity
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/29 00:44:49
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using UnityEngine;

namespace GOAP
{
    public interface IActionUnity
    {
        ActionUnityGroup ActionUnityGroup { get; }
    }

    [Serializable]
    public class ActionUnityGroup
    {
        #region 关联Unity中的信息

        public Animation Animation { get; }
        public AudioClip[] AudioClip { get; }
        public GameObject[] ParticleEffects { get; }

        #endregion
    }
}
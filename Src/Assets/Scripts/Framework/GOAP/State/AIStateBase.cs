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

using HutongGames.PlayMaker;

namespace GOAP
{
    [ActionCategory("AI/Base")]
    public abstract class AIStateBase : FsmStateAction, IState
    {
        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
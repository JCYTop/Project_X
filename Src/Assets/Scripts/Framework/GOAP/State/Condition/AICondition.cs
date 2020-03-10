/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AICondition
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 23:33:28
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using Framework.EventDispatcher;
using UnityEngine;

namespace Framework.GOAP
{
    public class AICondition : MonoEventEmitter, ICondition
    {
        //TODO 拿到当前状态
        //TODO 根据这个具体的Tag来判断
        delegate bool Method1(Transform trans);
    }
}
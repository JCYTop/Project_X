/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     FsmGetMono
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/05 17:30:55
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using HutongGames.PlayMaker;

/// <summary>
/// 获取Mono里面类
/// </summary>
/// <typeparam name="T">Mono类</typeparam>
public abstract class FsmGetMono<T> : FsmStateAction where T : UnityEngine.Object
{
    public FsmOwnerDefault GameObject;
    public FsmObject Context;

    public override void Awake()
    {
        base.Awake();
        var go = Fsm.GetOwnerDefaultTarget(GameObject);
        if (go == null)
            return;
        var context = go.GetComponent<T>();
        if (context != null)
            Context.Value = context;
    }
}
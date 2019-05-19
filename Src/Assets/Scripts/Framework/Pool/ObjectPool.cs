/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ObjectPool
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 15:29:48
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : ObjectPoolBase<T> where T : new()
{
    protected override IPoolable CreateObj()
    {
        var obj = new T();
        IPoolable poolable = null;
        if (obj is IPoolable)
        {
            poolable = obj as IPoolable;
            poolable.Pool = this;
        }

        return poolable;
    }
}
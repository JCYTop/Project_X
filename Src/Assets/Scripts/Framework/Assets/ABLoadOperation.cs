/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ABLoadOperation
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 17:12:22
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AB资源读取操作
/// </summary>
public abstract class ABLoadOperation : IEnumerator
{
    public bool MoveNext()
    {
        return !IsDone();
    }

    public void Reset()
    {
    }

    public object Current
    {
        get { return null; }
    }

    abstract public bool Update();

    abstract public bool IsDone();
}
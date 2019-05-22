/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     TagBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/21 18:54:21
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

/// <summary>
/// 设计标签类
/// </summary>
public interface ITagBase : IComponent
{
    string name { set; get; }
}
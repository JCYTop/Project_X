/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AuthorInfo
 *Author:       @JCY
 *Version:      
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/16 14:47:30
 *Description:   
 *History:
 ----------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorInfo : ScriptableObject
{
    [Header("作者名字")]  public string AuthorName = "@JCY";
    [Header("版本号")]  public string Version = "";
    [Header("作者邮箱")]  public string AuthorEmail = "jcyemail@qq.com";
    [Header("Unity开发版本")]  public string UnityVersion = "jcyemail@qq.com";
    [Header("留言")] public string Description = "";
}
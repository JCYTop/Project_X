/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     EnumMixed
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/13 22:03:02
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using NaughtyAttributes;

namespace NaughtyAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnumMixedAttribute : DrawerAttribute
    {
    }
}
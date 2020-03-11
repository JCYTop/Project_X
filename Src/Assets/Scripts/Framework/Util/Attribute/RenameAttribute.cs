/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     RenameAttribute
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/11 17:33:08
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/


using UnityEngine;

public class RenameAttribute : PropertyAttribute
{
    public string Name;

    public RenameAttribute(string name)
    {
        this.Name = name;
    }
}
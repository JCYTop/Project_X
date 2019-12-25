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

using Sirenix.OdinInspector;

namespace Framework.ScriptableObject
{
    public class AuthorInfo : UnityEngine.ScriptableObject
    {
        [InfoBox("作者名字")] public string AuthorName = "@JCY";
        [InfoBox("版本号")] public string Version = "";
        [InfoBox("作者邮箱")] public string AuthorEmail = "jcyemail@qq.com";
        [InfoBox("Unity开发版本")] public string UnityVersion = "jcyemail@qq.com";
        [InfoBox("留言")] public string Description = "";
    }
}
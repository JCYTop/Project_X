/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     FSMMgr
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 22:50:56
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

public class FSMMgr : Singleton<FSMMgr>
{
    public static Dictionary<string, FSM> FSMList = new Dictionary<string, FSM>();
}
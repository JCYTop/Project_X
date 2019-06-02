/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     FSMTranslation
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 16:43:38
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

public delegate bool Condition();

public class FSMTranslation
{
    public Condition Condition { private set; get; }
    public string ToStateName { private set; get; }
    public FSMCallback Callback { private set; get; }

    public FSMTranslation(Condition condition, string toStateName, FSMCallback callback = null)
    {
        Condition = condition;
        ToStateName = toStateName;
        Callback = callback;
    }
}
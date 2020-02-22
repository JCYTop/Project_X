/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/20 22:57:21
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace GOAP
{
    public interface IState
    {
        void Set(string key, bool value);
        void Set(IState otherState);
        bool Get(string key);
        void AddStateChangeListener(Action onChange);
        ICollection<string> GetKeys();
        bool ContainKey(string key);
        bool ContainState(IState otherState);
        void Clear();
        IState InversionValue();
    }
}
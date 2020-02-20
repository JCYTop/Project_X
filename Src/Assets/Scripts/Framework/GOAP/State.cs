/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     State
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/20 23:11:16
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace GOAP
{
    public class State : IState
    {
        private Dictionary<string, bool> _dataTable;
        private Action _onChange;

        public void SetState(string key, bool value)
        {
            if (_dataTable.ContainsKey(key) && _dataTable[key] != value)
            {
                ChangeValue(key, value);
            }
            else if (!_dataTable.ContainsKey(key))
            {
                ChangeValue(key, value);
            }
        }

        public bool GetValue(string key)
        {
            if (!_dataTable.ContainsKey(key))
            {
                // 报错
                return false;
            }

            return _dataTable[key];
        }

        private void ChangeValue(string key, bool value)
        {
            _dataTable[key] = value;
            _onChange?.Invoke();
        }

        public void AddStateChangeListener(Action onChange)
        {
            _onChange = onChange;
        }
    }
}
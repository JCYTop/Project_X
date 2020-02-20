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

public interface IState
{
    void SetState(string key, bool value);
    bool GetValue(string key);
    void AddStateChangeListener(Action onChange);
}

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
        throw new NotImplementedException();
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
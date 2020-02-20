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
using System.Text;

namespace GOAP
{
    public class State : IState
    {
        private Dictionary<string, bool> _dataTable;
        private Action _onChange;

        public State()
        {
            _dataTable = new Dictionary<string, bool>();
        }

        public void Set(string key, bool value)
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

        public void Set(IState otherState)
        {
            foreach (var key in otherState.GetKeys())
            {
                Set(key, otherState.Get(key));
            }
        }

        public ICollection<string> GetKeys()
        {
            return _dataTable.Keys;
        }

        public bool ContainKey(string key)
        {
            return _dataTable.ContainsKey(key);
        }

        public bool ContainState(IState otherState)
        {
            foreach (var key in otherState.GetKeys())
            {
                if (!ContainKey(key) || _dataTable[key] != otherState.Get(key))
                {
                    return false;
                }
            }

            return true;
        }

        public void Clear()
        {
            _dataTable.Clear();
        }

        public bool Get(string key)
        {
            if (!_dataTable.ContainsKey(key))
            {
                DebugMsg.Log("当前状态不包含此键值：" + key);
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

        public override string ToString()
        {
            var temp = new StringBuilder();
            foreach (var pair in _dataTable)
            {
                temp.Append("key : ");
                temp.Append(pair.Key);
                temp.Append("    Value : ");
                temp.Append(pair.Value);
                temp.Append("\r\n");
            }

            return temp.ToString();
        }
    }

    public class State<Tkey> : State
    {
        public State() : base()
        {
        }

        public void Set(Tkey key, bool value)
        {
            base.Set(key.ToString(), value);
        }

        public bool Get(Tkey key)
        {
            return base.Get(key.ToString());
        }

        public bool ContainKey(Tkey key)
        {
            return base.ContainKey(key.ToString());
        }
    }
}
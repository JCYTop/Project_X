using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.ScriptableObject
{
    public class ABInfo : UnityEngine.ScriptableObject
    {
        public List<ABData> ABDatas;
    }

    [Serializable]
    public class ABData
    {
        public long ID;
        public string name;
        public string Path;
        public string Des;
        public string Layer;
        public string Tag;
    }
}
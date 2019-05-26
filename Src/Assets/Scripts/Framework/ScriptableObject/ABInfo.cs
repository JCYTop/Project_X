using System;
using System.Collections.Generic;
using UnityEngine;

public class ABInfo : ScriptableObject
{
    public List<ABData> UIDatas;
}

[Serializable]
public class ABData
{
    public string name;
    public long ID;
    public string Path;
    public string Des;
    public string Type;
}
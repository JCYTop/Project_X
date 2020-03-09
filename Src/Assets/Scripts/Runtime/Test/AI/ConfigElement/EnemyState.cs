using System;
using UnityEngine;

namespace GOAP
{
    [Serializable]
    public class EnemyState : IStateAssembly<EnemyStateElementTag>
    {
        [Header("具体元素标签")] public EnemyStateElementTag ElementTag;
        [Header("标志位")] public bool IsRight = true;
    }
}
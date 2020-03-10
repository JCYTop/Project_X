using System.Collections.Generic;
using UnityEngine;

namespace Framework.GOAP
{
    /// <summary>
    /// 测试类
    /// 基本上和AIStateBase对应
    /// 但是也可以进行 多对一 匹配
    /// </summary>
    public class EnemyStateConfig : StateConfig
    {
        [Header("状态标签")] public StateTag Tag;
        [Header("状态元素")] public List<StateAssembly> StateElement;
    }
}
using System.Collections.Generic;

namespace Framework.GOAP
{
    /// <summary>
    /// 测试类
    /// 基本上和AIStateBase对应
    /// 但是也可以进行 多对一 匹配
    /// </summary>
    public class EnemyStateConfig : StateConfig
    {
        [Rename("状态标签")] public StateTag Tag;
        public List<StateAssembly> StateElement;
    }
}
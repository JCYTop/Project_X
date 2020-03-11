using System;
using UnityEngine;

namespace Framework.GOAP
{
    /// <summary>
    /// 存在进行判断
    /// 不存在忽略判断
    /// 应该专门写一个外部环境类保存时事计算参数 && 保存基础数值
    /// </summary>
    [Serializable]
    public class StateAssembly 
    {
        [Rename("元素标签")] public AIStateElementTag ElementTag;
        [Rename("标志位")] public bool IsRight = true;
    }
}
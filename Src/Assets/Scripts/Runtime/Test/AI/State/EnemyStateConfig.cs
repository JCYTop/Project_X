/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     EnemyConfig
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/26 22:05:21
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 测试类
    /// 基本上和AIStateBase对应
    /// 但是也可以进行 多对一 匹配
    /// </summary>
    public class EnemyStateConfig : StateConfig<AIStateElementTag>
    {
        public EnemyStateTag Tag;
        public bool Normal;

        public override StateConfig<AIStateElementTag> Init()
        {
            var normal = new BoolAggregation(Normal);
            stateConfigSet.Add(AIStateElementTag.Normal, normal);
            stateConfigSet.TryGetValue(AIStateElementTag.Bleed, out var data);
            return this;
        }
    }
}
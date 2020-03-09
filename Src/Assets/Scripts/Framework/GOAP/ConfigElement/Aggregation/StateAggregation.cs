/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     StateAggregation
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/08 23:19:08
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace Framework.GOAP
{
    public class StateAggregation<EnemyStateElementTag> : ConfigElementBase<IStateAssembly<EnemyStateElementTag>>
    {
        public StateAggregation(IStateAssembly<EnemyStateElementTag> value) : base(value)
        {
        }
    }
}
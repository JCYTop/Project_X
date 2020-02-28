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
    public class EnemyConfig : StateConfig
    {
        public int Bleed;

        public override StateConfig Init()
        {
            var Bleeds = new ValueAggregation(Bleed);
            stateConfigSet.Add(AIStateConfigElement.Bleed, Bleeds);
            stateConfigSet.TryGetValue(AIStateConfigElement.Bleed, out var data);
            return this;
        }
    }
}
using System;
using System.Collections.Generic;

namespace GOAP
{
    public class EnemyAllActionConfig : ActionConfig<ActionTag, ActionConfigElementTag>
    {
        public List<EnemyAllActionUnit> sss = new List<EnemyAllActionUnit>();

        public override ActionConfig<ActionTag, ActionConfigElementTag> Init()
        {
            throw new System.NotImplementedException();
        }
    }

    [Serializable]
    public class EnemyAllActionUnit
    {
        /// <summary>
        /// 具体的目标标签
        /// </summary>
        public ActionTag Tag;
        public EnemyActionConfigUnit Unit;
    }
}
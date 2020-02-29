using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class Test : MonoBehaviour
    {
        public int Bleed;
        protected SortedList<string, IConfigElementBase> stateConfigSet;

        private void Start()
        {
            #region State使用

            stateConfigSet = new SortedList<string, IConfigElementBase>();
            var Bleeds = new ValueAggregation(Bleed);
            stateConfigSet.Add(AIStateConfigElementTag.Bleed, Bleeds);
            stateConfigSet.TryGetValue(AIStateConfigElementTag.Bleed, out var data);
            var bleed = data.CastStateConfigEle<ValueAggregation>();

            #endregion

            #region Goal使用

            #endregion
        }
    }
}
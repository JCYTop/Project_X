using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class Test : MonoBehaviour
    {
        public int Bleed;
        protected SortedList<AIStateCommonElementTag, IConfigElement> stateConfigSet;

        private void Start()
        {
            #region State使用

            stateConfigSet = new SortedList<AIStateCommonElementTag, IConfigElement>();
            var Bleeds = new ValueAggregation(Bleed);
            stateConfigSet.Add(AIStateCommonElementTag.Bleed, Bleeds);
            stateConfigSet.TryGetValue(AIStateCommonElementTag.Bleed, out var data);
            var bleed = data.CastStateConfigEle<ValueAggregation>();

            #endregion

            #region Goal使用

            #endregion
        }
    }
}
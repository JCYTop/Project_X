using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class Test : MonoBehaviour
    {
        public int Bleed;
        protected SortedList<AIStateConfigElement, IStateConfigElementBase> stateConfigSet;

        private void Start()
        {
            stateConfigSet = new SortedList<AIStateConfigElement, IStateConfigElementBase>();
            var Bleeds = new ValueAggregation(Bleed);
            stateConfigSet.Add(AIStateConfigElement.Bleed, Bleeds);
            stateConfigSet.TryGetValue(AIStateConfigElement.Bleed, out var data);
            var bleed = data.CastStateConfigEle<ValueAggregation>();
        }
    }
}
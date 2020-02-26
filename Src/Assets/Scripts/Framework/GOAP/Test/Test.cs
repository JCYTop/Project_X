using System;
using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class Test : MonoBehaviour
    {
        public int Bleed;
        protected SortedList<AIConfigElement, IStateConfigElementBase> stateConfigSet;

        private void Start()
        {
            stateConfigSet = new SortedList<AIConfigElement, IStateConfigElementBase>();
            var Bleeds = new ValueAggregation(Bleed);
            stateConfigSet.Add(AIConfigElement.Bleed, Bleeds);
            stateConfigSet.TryGetValue(AIConfigElement.Bleed, out var data);
            var sss = data.GetTypeStateConfigElement<ValueAggregation>();
        }
    }
}
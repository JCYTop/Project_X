using System.Collections.Generic;
using UnityEngine;

namespace Framework.GOAP
{
    public class Test : MonoBehaviour
    {
        public int Bleed;
        protected SortedList<AIStateElementTag, IConfigElement> stateConfigSet;

        private void Start()
        {
            #region State使用
//
//            stateConfigSet = new SortedList<AIStateElementTag, IConfigElement>();
//            var Bleeds = new ValueAggregation(Bleed);
//            stateConfigSet.Add(AIStateElementTag.Bleed, Bleeds);
//            stateConfigSet.TryGetValue(AIStateElementTag.Bleed, out var data);
//            var bleed = data.CastStateConfigEle<ValueAggregation>();

            #endregion

            #region Goal使用

            #endregion
        }
    }
}
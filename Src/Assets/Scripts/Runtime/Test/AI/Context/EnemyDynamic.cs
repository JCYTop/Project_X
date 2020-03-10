using System.Collections.Generic;
using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyDynamic : AIDynamic
    {
        [Header("当前目标列表"), SerializeField] private List<GameObject> targets = new List<GameObject>();

        public List<GameObject> Targets
        {
            get { return targets; }
            set
            {
                targets = null;
                targets = value;
            }
        }

        public override void Init()
        {
            DynamicDic.Add(DynamicObjTag.Targets, Targets);
        }
    }
}
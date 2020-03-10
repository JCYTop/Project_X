using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyDynamic : AIDynamic
    {
        [Header("当前目标列表"), SerializeField] private GameObject targets;

        public GameObject Target
        {
            get { return targets; }
            set { targets = value; }
        }

        public override void Init()
        {
            DynamicDic.Add(DynamicObjTag.Normal_Target, Target);
        }
    }
}
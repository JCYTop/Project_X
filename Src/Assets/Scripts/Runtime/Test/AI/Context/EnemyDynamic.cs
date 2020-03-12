using Sirenix.OdinInspector;
using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyDynamic : AIDynamic
    {
//        [Rename("当前目标列表"), SerializeField, ReadOnly]
        [Rename("当前目标列表"), SerializeField] public GameObject Target;

        public override void Init()
        {
            DynamicDic.Add(DynamicObjTag.Normal_Target, () => { return Target; });
        }
    }
}
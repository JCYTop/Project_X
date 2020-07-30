using Sirenix.OdinInspector;
using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyDynamic : Dynamic
    {
        [Rename("目标"), SerializeField, OnValueChanged("Change_Target")]
        public GameObject Target;

        private void Change_Target()
        {
            OnEmitEvent(GOAPEventType.ChangeTarget, new object[] {GoalbalID, Target});
        }

        public override void Init()
        {
            DynamicDic.Add(DynamicObjTag.Target, () => { return Target; });
        }
    }
}
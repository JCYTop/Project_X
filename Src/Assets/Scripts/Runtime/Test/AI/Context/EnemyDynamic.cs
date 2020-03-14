using Sirenix.OdinInspector;
using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyDynamic : AIDynamic
    {
        [Rename("正常目标"), SerializeField, OnValueChanged("Change_Normal_Target")]
        public GameObject Normal_Target;

        private void Change_Normal_Target()
        {
            EmitEvent(GOAPEventType.Change_Normal_Target, new object[] {GoalbalID, Normal_Target,});
        }

        [Rename("攻击目标"), SerializeField, OnValueChanged("Change_Attack_Target")]
        public GameObject Attack_Target;

        private void Change_Attack_Target()
        {
        }

        public override void Init()
        {
            DynamicDic.Add(DynamicObjTag.Normal_Target, () => { return Normal_Target; });
            DynamicDic.Add(DynamicObjTag.Attack_Target, () => { return Attack_Target; });
        }
    }
}
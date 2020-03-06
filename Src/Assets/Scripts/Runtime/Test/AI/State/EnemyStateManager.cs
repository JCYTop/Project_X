using System.Collections.Generic;

namespace GOAP
{
    public class EnemyStateManager : StateManagerBase<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>>
    {
        private SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> stateDic;
        public override SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> StateDic => stateDic;

        public EnemyStateManager()
        {
            stateDic = new SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>>();
        }

        public override SortedList<TStateTag, TStateBase> GetStateList<TStateTag, TStateBase>()
        {
            throw new System.NotImplementedException();
        }
    }
}
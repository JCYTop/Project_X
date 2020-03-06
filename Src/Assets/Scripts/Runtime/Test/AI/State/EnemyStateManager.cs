using System.Collections.Generic;

namespace GOAP
{
    public class EnemyStateManager : StateManagerBase
    {
        private SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> stateDic;
        public SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> StateDic => stateDic;

        public EnemyStateManager()
        {
            stateDic = new SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>>();
        }

        public override SortedList<TStateTag, AIStateBase<TContext, TConfig>> GetStateList<TStateTag, TContext, TConfig>()
        {
        }
    }
}
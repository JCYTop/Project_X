using System.Collections.Generic;
using Framework.Event;

namespace Framework.GOAP
{
    public class EnemyStateMgr : StateMgr<AIState<EnemyContext, EnemyStateConfig>>
    {
        private StateTag currStateTag;
        private AIState<EnemyContext, EnemyStateConfig> currState;
        private SortedList<StateTag, AIState<EnemyContext, EnemyStateConfig>> stateSortList;
        public override SortedList<StateTag, AIState<EnemyContext, EnemyStateConfig>> StateSortList => stateSortList;
        public override StateTag CurrStateTag => currStateTag;
        public override IState CurrState => currState;

        public EnemyStateMgr()
        {
            stateSortList = new SortedList<StateTag, AIState<EnemyContext, EnemyStateConfig>>();
        }

        public override void SetCurrActivity(StateTag tag)
        {
            if (!StateSortList.ContainsKey(tag))
            {
                LogTool.LogError($"未发现注册 {tag} 标签");
                return;
            }

            currStateTag = tag;
            currState = stateSortList[tag];
        }
    }
}
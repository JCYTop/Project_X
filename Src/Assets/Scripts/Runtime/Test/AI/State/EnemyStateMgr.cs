using System.Collections.Generic;

namespace Framework.GOAP
{
    public class EnemyStateMgr : StateMgrBase<AIStateBase<EnemyContext, EnemyStateConfig>>
    {
        private StateTag currStateTag;
        private AIStateBase<EnemyContext, EnemyStateConfig> currState;
        private SortedList<StateTag, AIStateBase<EnemyContext, EnemyStateConfig>> stateSortList;
        public override SortedList<StateTag, AIStateBase<EnemyContext, EnemyStateConfig>> StateSortList => stateSortList;
        public override StateTag CurrStateTag => currStateTag;
        public override IState CurrState => currState;

        public EnemyStateMgr()
        {
            stateSortList = new SortedList<StateTag, AIStateBase<EnemyContext, EnemyStateConfig>>();
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
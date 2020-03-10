using System.Collections.Generic;

namespace Framework.GOAP
{
    public class EnemyStateMgr : StateMgrBase<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>>
    {
        private EnemyStateTag currStateTag;
        private AIStateBase<EnemyContext, EnemyStateConfig> currState;
        private SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> stateSortList;
        public override SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> StateSortList => stateSortList;
        public override EnemyStateTag CurrStateTag => currStateTag;
        public override IState CurrState => currState;

        public EnemyStateMgr()
        {
            stateSortList = new SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>>();
        }

        public override void SetCurrActivity(EnemyStateTag tag)
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
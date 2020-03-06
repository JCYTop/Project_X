namespace GOAP
{
    public class EnemyActionManager : ActionManagerBase<ActionEnemyTag, GoalEnemyTag>
    {
        public EnemyActionManager(IAgent<ActionEnemyTag, GoalEnemyTag> agent) : base(agent)
        {
            //TODO 有必要保持传值吗？？？？？？？？？？？？？？？？？？？
        }

        protected override void InitActionHandlers()
        {
            throw new System.NotImplementedException();
        }

        protected override void InitActionStateHandlers()
        {
            throw new System.NotImplementedException();
        }

        protected override void InitEffectsAndActionMap()
        {
            throw new System.NotImplementedException();
        }

        protected override void InitInterruptibleDic()
        {
            throw new System.NotImplementedException();
        }

        public override ActionEnemyTag GetDefaultActionLabel()
        {
            throw new System.NotImplementedException();
        }
    }
}
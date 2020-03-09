namespace GOAP
{
    /// <summary>
    /// 用在具体的生成类
    /// </summary>
    public class EnemyAction : ActionBase<ActionEnemyTag, ActionElementTag>
    {
        public EnemyAction(ActionEnemyTag tag, ActionConfigUnit<ActionElementTag> actionGroup) : base(tag, actionGroup)
        {
        }
    }
}
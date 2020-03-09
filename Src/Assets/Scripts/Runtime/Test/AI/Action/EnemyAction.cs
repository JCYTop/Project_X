namespace GOAP
{
    /// <summary>
    /// 用在具体的生成类
    /// </summary>
    public class EnemyAction : ActionBase<ActionEnemyTag, EnemyActionElementTag>
    {
        public EnemyAction(ActionEnemyTag tag, ActionConfigUnit<EnemyActionElementTag> actionGroup) : base(tag, actionGroup)
        {
        }
    }
}
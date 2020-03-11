namespace Framework.GOAP
{
    /// <summary>
    /// 用在具体的生成类
    /// </summary>
    public class EnemyAction : ActionBase<ActionTag, ActionElementTag>
    {
        public EnemyAction(ActionTag tag, ActionConfigUnit<ActionElementTag> actionGroup) : base(tag, actionGroup)
        {
        }
    }
}
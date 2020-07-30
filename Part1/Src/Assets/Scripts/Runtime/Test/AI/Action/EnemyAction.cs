namespace Framework.GOAP
{
    /// <summary>
    /// 用在具体的生成类
    /// </summary>
    public class EnemyAction : Action<ActionTag>
    {
        public EnemyAction(ActionTag tag, ActionConfigUnit actionGroup) : base(tag, actionGroup)
        {
        }
    }
}
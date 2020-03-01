namespace GOAP
{
    public class EnemyActionConfigUnit : ActionConfigUnit<ActionConfigElementTag>
    {
        public int Priority;

        public override ActionConfigUnit<ActionConfigElementTag> Init()
        {
            var priority = new ValueAggregation(Priority);
            actionConfigUnitSet.Add(ActionConfigElementTag.Priority, priority);
            return this;
        }
    }
}
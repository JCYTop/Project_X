using System;
using System.Collections.Generic;

namespace GOAP
{
    public class EnemyAllActionConfig : ActionConfig<ActionTag, ActionConfigElementTag>
    {
        public List<EnemyAllActionUnit> allAction = new List<EnemyAllActionUnit>();

        public override SortedList<ActionTag, ActionConfigUnit<ActionConfigElementTag>> Init()
        {
            var actionSort = new SortedList<ActionTag, ActionConfigUnit<ActionConfigElementTag>>();
            allAction.ForEach((action) => { actionSort.Add(action.Tag, action.Unit.Init()); });
            LogTool.Log($" --- {this.name} , Action数据已经加载完成 --->>> 共计${allAction.Count}个", LogEnum.AssetLog);
            return actionSort;
        }
    }

    [Serializable]
    public class EnemyAllActionUnit
    {
        /// <summary>
        /// 具体的目标标签
        /// </summary>
        public ActionTag Tag;

        public EnemyActionConfigUnit Unit;
    }
}
using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace GOAP
{
    public class EnemyAllActionConfig : ActionConfig<ActionCommonTag, ActionConfigElementTag>
    {
        public List<EnemyAllActionUnit> allAction = new List<EnemyAllActionUnit>();

        public override SortedList<ActionCommonTag, ActionConfigUnit<ActionConfigElementTag>> Init()
        {
            var actionSort = new SortedList<ActionCommonTag, ActionConfigUnit<ActionConfigElementTag>>();
            allAction.ForEach((action) => { actionSort.Add(action.commonTag, action.Unit.Init()); });
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
        [FormerlySerializedAs("Tag")] public ActionCommonTag commonTag;

        public EnemyActionConfigUnit Unit;
    }
}
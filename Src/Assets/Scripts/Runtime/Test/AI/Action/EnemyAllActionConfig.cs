using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace GOAP
{
    public class EnemyAllActionConfig : ActionConfig<ActionEnemyTag, ActionElementTag>
    {
        public List<EnemyAllActionUnit> allAction = new List<EnemyAllActionUnit>();

        public override SortedList<ActionEnemyTag, ActionConfigUnit<ActionElementTag>> Init()
        {
            var actionSort = new SortedList<ActionEnemyTag, ActionConfigUnit<ActionElementTag>>();
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
        [FormerlySerializedAs("Tag")] public ActionEnemyTag commonTag;

        public EnemyActionConfigUnit Unit;
    }
}
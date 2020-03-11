using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Framework.GOAP
{
    public class EnemyAllActionConfig : ActionConfig<ActionTag, ActionElementTag>
    {
        public List<EnemyAllActionUnit> allAction = new List<EnemyAllActionUnit>();

        public override SortedList<ActionTag, ActionConfigUnit<ActionElementTag>> Init()
        {
            var actionSort = new SortedList<ActionTag, ActionConfigUnit<ActionElementTag>>();
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
        [FormerlySerializedAs("Tag")] public ActionTag commonTag;

        public EnemyActionConfigUnit Unit;
    }
}
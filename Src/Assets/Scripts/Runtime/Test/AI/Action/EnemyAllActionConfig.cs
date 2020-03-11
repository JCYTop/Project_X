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
            allAction.ForEach((action) => { actionSort.Add(action.commonTag, action.File.Init()); });
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
        [Rename("标签")] public ActionTag commonTag;

        [Rename("配置文件")] public EnemyActionConfigUnit File;
    }
}
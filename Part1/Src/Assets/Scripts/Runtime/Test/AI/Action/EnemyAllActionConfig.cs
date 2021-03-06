using System;
using System.Collections.Generic;

namespace Framework.GOAP
{
    public class EnemyAllActionConfig : ActionConfig<ActionTag>
    {
        public List<EnemyAllActionUnit> allAction = new List<EnemyAllActionUnit>();

        public override SortedList<ActionTag, ActionConfigUnit> Init()
        {
            var actionSort = new SortedList<ActionTag, ActionConfigUnit>();
            allAction.ForEach((action) =>
            {
                if (action.File != null)
                {
                    action.File.Init();
                    actionSort.Add(action.commonTag, action.File.GetConfigUnit);
                }
                else
                {
                    LogTool.Log($"File文件缺失");
                }
            });
            LogTool.Log($" --- {this.name} , Action数据已经加载完成 --->>> 共计${allAction.Count}个", LogEnum.AssetLog);
            return actionSort;
        }
    }

    [Serializable]
    public class EnemyAllActionUnit
    {
        [Rename("标签")] public ActionTag commonTag;
        [Rename("配置")] public EnemyActionConfigUnit File;
    }
}
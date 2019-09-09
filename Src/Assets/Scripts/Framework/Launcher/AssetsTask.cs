//=====================================================
// - FileName:      AssetsTask.cs
// - Created:       @JCY
// - CreateTime:    2019/03/24 11:31:00
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

public class AssetsTask : ILanucherTask
{
    public override string Name
    {
        get => "资源管理启动";
    }

    public override TaskType TaskType
    {
        get => TaskType.AssetsTask;
    }

    public override void AddTaskChild()
    {
        StartAsset();
    }

    private void StartAsset()
    {
        LogUtil.Log(string.Format(Name), LogType.TaskLog);
        AssetsManager.Instance();
        AssetBundleManager.Instance();
        AssetBundleLoader.Instance();
        CalcTaskCount();
    }
}
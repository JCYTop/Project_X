using System.Collections.Generic;
using UnityEngine.Events;

public class UnityActionMgr : Singleton<UnityActionMgr>
{
    #region 字段

    /// <summary>
    /// 物体运行前调用
    /// </summary>
    private static Dictionary<int, UnityAction> beforeUnityAction = new Dictionary<int, UnityAction>();

    /// <summary>
    /// 每次Enable时候调用
    /// </summary>
    private static Dictionary<int, UnityAction> enableUnityAction = new Dictionary<int, UnityAction>();

    /// <summary>
    /// 每次Disable时候调用
    /// </summary>
    private static Dictionary<int, UnityAction> disableUnityAction = new Dictionary<int, UnityAction>();

    /// <summary>
    /// 物体销毁时时候调用
    /// </summary>
    private static Dictionary<int, UnityAction> afterUnityAction = new Dictionary<int, UnityAction>();

    private Dictionary<RunTimeUnityAction, Dictionary<int, UnityAction>> choseDic = new Dictionary<RunTimeUnityAction, Dictionary<int, UnityAction>>()
    {
        {RunTimeUnityAction.Before, beforeUnityAction},
        {RunTimeUnityAction.Enable, enableUnityAction},
        {RunTimeUnityAction.DisEnable, disableUnityAction},
        {RunTimeUnityAction.After, afterUnityAction},
    };

    #endregion

    public UnityAction AddUnityAction(int target, UnityAction unityAction, RunTimeUnityAction runTime)
    {
        var dic = choseDic[runTime];
        var action = unityAction;
        if (!dic.ContainsKey(target))
        {
            dic.Add(target, unityAction);
        }
        else
        {
            action = dic[target];
            action += unityAction;
        }

        return action;
    }

    public bool RunUnityAction(int target, RunTimeUnityAction runTime)
    {
        var dic = choseDic[runTime];
        var isRun = false;
        if (dic.ContainsKey(target))
        {
            var action = dic[target];
            action();
            return isRun = true;
        }

        return isRun = false;
    }
}

public enum RunTimeUnityAction
{
    Before,
    Enable,
    DisEnable,
    After,
}
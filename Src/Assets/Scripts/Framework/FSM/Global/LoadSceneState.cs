/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     LoadSceneState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 19:52:41
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using HutongGames.PlayMaker;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

[ActionCategory("GlobalState.LoadSceneState")]
public class LoadSceneState : GlobalState
{
    public string SceneName;
    [ArrayEditor(VariableType.String)] public FsmArray AddressName;

    public override void OnEnter()
    {
        base.OnEnter();
        LogTool.Log($"LoadSceneState", LogEnum.State);
        AddressableAsyncAdapter.LoadSceneAsync(SceneName, LoadSceneMode.Single, (conplete) =>
        {
            conplete.Completed += handle =>
            {
                if (conplete.Status == AsyncOperationStatus.Succeeded)
                {
                    LogTool.Log($"场景切换完成 {conplete.Result}");
                }
            };
        });
        foreach (var value in AddressName.Values)
        {
            AddressableAsyncAdapter.InstantiateAsync(value.ToString(), (conplete) =>
            {
                if (conplete.Status == AsyncOperationStatus.Succeeded)
                {
                    LogTool.Log($"资源加载完成 {conplete.Result}");
                }
            });
        }
    }
}
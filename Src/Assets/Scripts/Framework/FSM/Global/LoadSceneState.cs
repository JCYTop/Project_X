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

using System.Collections;
using HutongGames.PlayMaker;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

[ActionCategory("GlobalState.LoadSceneState")]
public class LoadSceneState : GlobalState
{
    public string SceneName;
    [ArrayEditor(VariableType.String)] public FsmArray AddressNameAsync;
    [ArrayEditor(VariableType.String)] public FsmArray AddressNameSync;

    public override void OnEnter()
    {
        base.OnEnter();
        LogTool.Log($"LoadSceneState", LogEnum.State);
        AddressableAsync.LoadSceneAsync(SceneName, LoadSceneMode.Single, () =>
        {
            LogTool.Log($"场景切换完成 ");
            foreach (var value in AddressNameAsync.Values)
            {
                AddressableAsync.InstantiateAsync(value.ToString(), (go) =>
                {
                    Debug.Log($"{go.name}");
                });
            }

            StartCoroutine(HandleSync());
        });
   
    }

    private IEnumerator HandleSync()
    {
        foreach (var value in AddressNameSync.Values)
        {
            var operation = AddressableAsync.InstantiateAsync(value.ToString(), (go) =>
            {
                Debug.Log($"{go.name}");
            });
            yield return operation;
        }
    }
}
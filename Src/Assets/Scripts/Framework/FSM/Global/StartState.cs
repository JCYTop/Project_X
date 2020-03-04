/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     StartState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 19:52:41
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using Framework.Assets;
using HutongGames.PlayMaker;
using UnityEngine.SceneManagement;

[ActionCategory("GlobalState")]
public class StartState : GlobalState
{
    public override void OnEnter()
    {
        base.OnEnter();
        LogTool.Log(string.Format("StartState"), LogEnum.State);
        SceneManager.LoadScene(GlobalDefine.StartScene);
        AssetsManager.Instance().GetPrefabAsync("Main Camera", (prefab) =>
        {
            if (prefab != null)
            {
                EntityUtil.InstantiateGo(prefab, false);
            }
        });
    }
}
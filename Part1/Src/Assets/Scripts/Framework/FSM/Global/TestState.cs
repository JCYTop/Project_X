/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     TestState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/26 23:47:40
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using HutongGames.PlayMaker;
using UnityEngine.SceneManagement;

[ActionCategory("SceneState.TestState")]
public class TestState : SceneState
{
    public override void OnEnter()
    {
        base.OnEnter();
        LogTool.Log(string.Format("StartState"), LogEnum.State);
        SceneManager.LoadScene(GlobalDefine.TestScene);
    }
}
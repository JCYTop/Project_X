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

[ActionCategory("GlobalState")]
public class TestState : GlobalState
{
    public override void OnEnter()
    {
        base.OnEnter();
        LogUtil.Log(string.Format("StartState"), LogType.State);
        SceneManager.LoadScene(GlobalDefine.TestScene);
    }
}
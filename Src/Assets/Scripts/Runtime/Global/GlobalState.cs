/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AwakeGame
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 19:45:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;

public class GlobalState : MonoBehaviour
{
    private FSM globalFSM;

    void Awake()
    {
        DontDestroyOnLoad(this);
        globalFSM = new FSM("GlobalFSM");
        globalFSM.StartState(new AwakeState());
        globalFSM.AddState(new StartState());
    }

    void Update()
    {
        globalFSM.UpdateState();
    }
}
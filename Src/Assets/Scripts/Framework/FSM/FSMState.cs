/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     FSMState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 16:40:58
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

public abstract class FSMState
{
    protected List<FSMTranslation> translation = new List<FSMTranslation>();
    public string Name { set; get; }

    public List<FSMTranslation> Translation
    {
        get => translation;
    }

    public FSMState(string name)
    {
        Name = name;
        InitTranslation();
    }

    public FSMState()
    {
        InitTranslation();
    }

    public abstract void InitTranslation();

    /// <summary>
    /// 进入状态
    /// </summary>
    public abstract void OnEnter();

    /// <summary>
    /// 进行状态
    /// </summary>
    public abstract void OnUpdate();

    /// <summary>
    /// 离开状态
    /// </summary>
    public abstract void OnExit();
}
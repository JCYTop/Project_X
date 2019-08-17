/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     CharacterBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/13 21:06:27
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterBase : ObjectBase
{
    [BoxGroup("角色属性设置"), InfoBox("角色注册类型"), SerializeField]
    private Character Options = Character.Player;

    public override void Init()
    {
        ScenesMgr.AddGameObjectInfo<Character>(globalID, (int) Options, this);
    }

    public override void Release()
    {
        ScenesMgr.RemoveGameObjectInfo<Character>(globalID, (int) Options);
    }
}

[Flags]
public enum Character
{
    None = 0,
    Player = 1,
    Enemy = 1 << 1,
    Boss = 1 << 2,
    NPC = 1 << 3,
    ALL = Player | Enemy | Boss | NPC
}
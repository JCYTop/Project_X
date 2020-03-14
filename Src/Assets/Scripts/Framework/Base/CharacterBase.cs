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

namespace Framework.Base
{
    public class CharacterBase : ObjectBase
    {
        [BoxGroup("基本属性手动设置"), SerializeField] private Character objectSubTag = Character.Player;

        public override void Init()
        {
            ScenesCenterMgr.AddGameObjectInfo<Character>(globalID, (int) objectSubTag, this);
        }

        public override void Release()
        {
            ScenesCenterMgr.RemoveGameObjectInfo<Character>(globalID, (int) objectSubTag);
        }
    }

    [Flags]
    public enum Character
    {
        Default = 0,
        Player = 1,
        Robot = 1 << 1,
        Enemy = 1 << 2,
        Boss = 1 << 3,
        NPC = 1 << 4,
        ALL = Player | Robot | Enemy | Boss | NPC,
    }
}
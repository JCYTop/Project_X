/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GameObjectBase
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/16 18:23:45
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using Sirenix.OdinInspector;
using UnityEngine;

namespace Framework.Base
{
    public class GameObjectBase : ObjectBase
    {
        [BoxGroup("基本属性手动设置"), SerializeField, EnumPaging]
        private ObjSubTag objectSubTag = ObjSubTag.Default;

        public override void Init()
        {
        }

        public override void Release()
        {
        }
    }

    public enum ObjSubTag
    {
        Default,
    }
}
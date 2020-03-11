/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     RenameAttributeDrawer
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/11 17:34:13
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RenameAttribute))]
public class RenameAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var attr = (RenameAttribute) base.attribute;
        label.text = attr.Name;
        EditorGUI.PropertyField(position, property, label);
    }
}
/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     EnumMixedDrawer
 *Author:       @JCY
 *Version:      0.0.1 
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/13 22:05:59
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/


using UnityEditor;
using UnityEngine;

namespace NaughtyAttributes.Editor
{
    [PropertyDrawer(typeof(EnumMixedAttribute))]
    public class EnumMixedDrawer : PropertyDrawer
    {
        public override void DrawProperty(SerializedProperty property)
        {
            property.intValue = EditorGUILayout.MaskField(property.name, property.intValue, property.enumNames);
        }
    }
}
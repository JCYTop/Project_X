/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     HexCoordinatesDrawer
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/25 22:01:14
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEditor;
using UnityEngine;

namespace Runtime.HexMap.Editor
{
    [CustomPropertyDrawer(typeof(HexCoordinates))]
    public class HexCoordinatesDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var coordinates = new HexCoordinates(property.FindPropertyRelative("x").intValue, property.FindPropertyRelative("z").intValue);
            position = EditorGUI.PrefixLabel(position, label);
            GUI.Label(position, coordinates.ToString());
        }
    }
}
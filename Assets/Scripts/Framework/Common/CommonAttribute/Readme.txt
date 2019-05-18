How to create your own attributes
Lets say you want to implement your own [ReadOnly] attribute.

First you have to create a ReadOnlyAttribute class

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class ReadOnlyAttribute : DrawerAttribute
{
}
Then you need to create a drawer for that attribute

[PropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyPropertyDrawer : PropertyDrawer
{
	public override void DrawProperty(SerializedProperty property)
	{
		GUI.enabled = false;
		EditorGUILayout.PropertyField(property, true);
		GUI.enabled = true;
	}
}
Last, in order for the editor to recognize the drawer for this attribute, you have to press the Tools/NaughtyAttributes/Update Attributes Database menu item in the editor.
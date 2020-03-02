using System.Linq;
using UnityEditor;

namespace Ludiq.PeekCore
{
	public class AnnotationDisabler
	{
		[MenuItem("Tools/Peek/Ludiq/Internal/Disable Gizmos", priority = LudiqProduct.InternalToolsMenuPriority + 502)]
		public static void DisableGizmos()
		{
			foreach (var type in Codebase.types.Where(type => type.HasAttribute<DisableAnnotationAttribute>()))
			{
				var attribute = type.GetAttribute<DisableAnnotationAttribute>();

				var annotation = AnnotationUtility.GetAnnotation(type);

				if (annotation != null)
				{
					annotation.iconEnabled = !attribute.disableIcon;
					annotation.gizmoEnabled = !attribute.disableGizmo;
				}
			}
		}
	}
}
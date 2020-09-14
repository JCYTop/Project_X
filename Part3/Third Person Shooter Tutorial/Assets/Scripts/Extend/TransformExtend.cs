using UnityEngine;

namespace Extend
{
    public static class TransformExtend
    {
        public static Transform FindInChild(this Transform parent, string name)
        {
            if (parent.name.Equals(name))
                return parent;
            if (parent.childCount < 1)
                return null;
            Transform target = null;
            for (int i = 0; i < parent.childCount; i++)
            {
                var t = parent.GetChild(i).transform;
                target = FindInChild(t, name);
                if (target != null)
                    break;
            }

            return target;
        }
    }
}
using UnityEngine;

namespace UnDo
{
    public class MeshDeformerInput : MonoBehaviour
    {
        public float force = 10f;
        public float forceOffset = 0.1f;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                HandleInput();
            }

            void HandleInput()
            {
                var inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(inputRay, out hit))
                {
                    var deformer = hit.collider.GetComponent<MeshDeformer>();
                    if (deformer)
                    {
                        var point = hit.point;
                        point += hit.normal * forceOffset;
                        deformer.AddDeformingForce(point, force);
                    }
                }
            }
        }
    }
}
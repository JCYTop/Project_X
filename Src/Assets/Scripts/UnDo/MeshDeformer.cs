using UnityEngine;

namespace UnDo
{
    [RequireComponent(typeof(MeshFilter))]
    public class MeshDeformer : MonoBehaviour
    {
        private Mesh deformingMesh;
        private Vector3[] originalVertices;
        private Vector3[] displacedVertices;
        private Vector3[] vertexVelocities;
        public float springForce = 20f;
        public float damping = 5f;
        private float uniformScale = 1f;

        private void Start()
        {
            deformingMesh = GetComponent<MeshFilter>().mesh;
            originalVertices = deformingMesh.vertices;
            displacedVertices = new Vector3[originalVertices.Length];
            for (int i = 0; i < originalVertices.Length; i++)
            {
                displacedVertices[i] = originalVertices[i];
            }

            vertexVelocities = new Vector3[originalVertices.Length];
        }

        void Update()
        {
            uniformScale = transform.localScale.x;
            for (int i = 0; i < displacedVertices.Length; i++)
            {
                UpdateVertex(i);
            }

            deformingMesh.vertices = displacedVertices;
            deformingMesh.RecalculateNormals();

            void UpdateVertex(int i)
            {
                var velocity = vertexVelocities[i];
                var displacement = displacedVertices[i] - originalVertices[i];
                displacement *= uniformScale;
                velocity -= displacement * springForce * Time.deltaTime;
                velocity *= 1f - damping * Time.deltaTime;
                vertexVelocities[i] = velocity * (Time.deltaTime / uniformScale);
                displacedVertices[i] += velocity * Time.deltaTime;
            }
        }

        public void AddDeformingForce(Vector3 point, float force)
        {
            Debug.DrawLine(Camera.main.transform.position, point);
            point = transform.InverseTransformPoint(point);
            for (int i = 0; i < displacedVertices.Length; i++)
            {
                AddForceToVertex(i, point, force);
            }
        }

        private void AddForceToVertex(int i, Vector3 point, float force)
        {
            var pointToVertex = displacedVertices[i] - point;
            pointToVertex *= uniformScale;
            var attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
            var velocity = attenuatedForce * Time.deltaTime;
            vertexVelocities[i] += pointToVertex.normalized * velocity;
        }
    }
}
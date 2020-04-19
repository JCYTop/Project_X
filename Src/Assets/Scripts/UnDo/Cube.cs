using UnityEngine;

namespace UnDo
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Cube : MonoBehaviour
    {
        private Mesh mesh;
        private Vector3[] vertices;
        public int xSize;
        public int ySize;
        public int zSize;

        private void Awake()
        {
            Generate();
        }

        private void Generate()
        {
            GetComponent<MeshFilter>().mesh = mesh = new Mesh();
            mesh.name = "Procedural Cube";
            CreateVertices();
            CreateTriangles();
        }

        /// <summary>
        /// 创建所有的顶点
        /// </summary>
        private void CreateVertices()
        {
            var cornerVertices = 8;
            var edgeVertices = (xSize + ySize + zSize - 3) * 4;
            var faceVertices = ((xSize - 1) * (ySize - 1) + (xSize - 1) * (zSize - 1) + (ySize - 1) * (zSize - 1)) * 2;
            vertices = new Vector3[cornerVertices + edgeVertices + faceVertices];
            var v = 0;
            for (int y = 0; y <= ySize; y++)
            {
                for (int x = 0; x <= xSize; x++)
                {
                    vertices[v++] = new Vector3(x, y, 0);
                }

                for (int z = 1; z <= zSize; z++)
                {
                    vertices[v++] = new Vector3(xSize, y, z);
                }

                for (int x = xSize - 1; x >= 0; x--)
                {
                    vertices[v++] = new Vector3(x, y, zSize);
                }

                for (int z = zSize - 1; z > 0; z--)
                {
                    vertices[v++] = new Vector3(0, y, z);
                }
            }

            for (int z = 1; z < zSize; z++)
            {
                for (int x = 1; x < xSize; x++)
                {
                    vertices[v++] = new Vector3(x, ySize, z);
                }
            }

            for (int z = 1; z < zSize; z++)
            {
                for (int x = 1; x < xSize; x++)
                {
                    vertices[v++] = new Vector3(x, 0, z);
                }
            }

            mesh.vertices = vertices;
        }

        /// <summary>
        /// 创建所有三角面
        /// </summary>
        private void CreateTriangles()
        {
            var quads = (xSize * ySize + xSize * zSize + ySize * zSize) * 2;
            var triangles = new int [quads * 6];
            var ring = (xSize + zSize) * 2;
            var t = 0;
            var v = 0;
            //创建围绕的三角面
            for (int y = 0; y < ySize; y++, v++)
            {
                for (int q = 0; q < ring - 1; q++, v++)
                {
                    t = SetQuad(triangles, t, v, v + 1, v + ring, v + ring + 1);
                }

                t = SetQuad(triangles, t, v, v - ring + 1, v + ring, v + 1);
            }

            //创建顶部的三角面
            t = CreateTopFace(triangles, t, ring);
            t = CreateBottomFace(triangles, t, ring);
            mesh.triangles = triangles;
        }

        private int CreateBottomFace(int[] triangles, int t, int ring)
        {
            var v = 1;
            var vMid = vertices.Length - (xSize - 1) * (zSize - 1);
            t = SetQuad(triangles, t, ring - 1, vMid, 0, 1);
            for (int x = 1; x < xSize - 1; x++, v++, vMid++)
            {
                t = SetQuad(triangles, t, vMid, vMid + 1, v, v + 1);
            }

            t = SetQuad(triangles, t, vMid, v + 2, v, v + 1);
            var vMin = ring - 2;
            vMid -= xSize - 2;
            var vMax = v + 2;
            for (int z = 1; z < zSize - 1; z++, vMin--, vMid++, vMax++)
            {
                t = SetQuad(triangles, t, vMin, vMid + xSize - 1, vMin + 1, vMid);
                for (int x = 1; x < xSize - 1; x++, vMid++)
                {
                    t = SetQuad(
                        triangles, t,
                        vMid + xSize - 1, vMid + xSize, vMid, vMid + 1);
                }

                t = SetQuad(triangles, t, vMid + xSize - 1, vMax + 1, vMid, vMax);
            }

            int vTop = vMin - 1;
            t = SetQuad(triangles, t, vTop + 1, vTop, vTop + 2, vMid);
            for (int x = 1; x < xSize - 1; x++, vTop--, vMid++)
            {
                t = SetQuad(triangles, t, vTop, vTop - 1, vMid, vMid + 1);
            }

            t = SetQuad(triangles, t, vTop, vTop - 1, vMid, vTop - 2);

            return t;
        }

        private int CreateTopFace(int[] triangles, int t, int ring)
        {
            var v = ring * ySize;
            for (int x = 0; x < xSize - 1; x++, v++)
            {
                t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + ring);
            }

            t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + 2);
            //创建夹在中间的三角面
            //
            var vMin = ring * (ySize + 1) - 1;
            var vMid = vMin + 1;
            var vMax = v + 2;
            for (int z = 1; z < zSize - 1; z++, vMin--, vMid++, vMax++)
            {
                t = SetQuad(triangles, t, vMin, vMid, vMin - 1, vMid + xSize - 1);
                for (int x = 1; x < xSize - 1; x++, vMid++)
                {
                    t = SetQuad(triangles, t, vMid, vMid + 1, vMid + xSize - 1, vMid + xSize);
                }

                t = SetQuad(triangles, t, vMid, vMax, vMid + xSize - 1, vMax + 1);
            }

            //
            var vTop = vMin - 2;
            t = SetQuad(triangles, t, vMin, vMid, vTop + 1, vTop);
            for (int x = 1; x < xSize - 1; x++, vTop--, vMid++)
            {
                t = SetQuad(triangles, t, vMid, vMid + 1, vTop, vTop - 1);
            }

            t = SetQuad(triangles, t, vMid, vTop - 2, vTop, vTop - 1);
            return t;
        }

        private static int SetQuad(int[] triangles, int i, int v00, int v10, int v01, int v11)
        {
            triangles[i] = v00;
            triangles[i + 1] = triangles[i + 4] = v01;
            triangles[i + 2] = triangles[i + 3] = v10;
            triangles[i + 5] = v11;
            return i + 6;
        }

        private void OnDrawGizmos()
        {
            if (vertices == null)
            {
                return;
            }

            Gizmos.color = Color.black;
            for (int i = 0; i < vertices.Length; i++)
            {
                Gizmos.DrawSphere(vertices[i], 0.1f);
            }
        }
    }
}
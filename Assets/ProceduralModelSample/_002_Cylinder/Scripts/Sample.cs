using System.Collections.Generic;
using OGL.ProceduralModelingKit;
using UnityEngine;

namespace ProceduralModelSample._002_Quad
{
    public class Sample : ProceduralModelBase
    {
        [SerializeField] private float radius = 1f;
        [SerializeField] private float height = 3f;
        [SerializeField] private int segment = 3;

        protected override Mesh CreateMesh()
        {
            Mesh resultMesh = new Mesh();

            List<Vector3> posList = new List<Vector3>();
            List<Vector2> uvList = new List<Vector2>();
            List<Vector3> normalList = new List<Vector3>();
            List<int> indexList = new List<int>();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < segment + 1; j++)
                {
                    float xUv = (float) j / segment;
                    float radian = xUv * Mathf.PI * 2f;

                    float cos = Mathf.Cos(radian);
                    float sin = Mathf.Sin(radian);
                    float xPos = cos * radius;
                    float yPos = sin * radius;
                    posList.Add(new Vector3(xPos, height / 2f, yPos));
                    uvList.Add(new Vector2(xUv, 1f));
                    posList.Add(new Vector3(xPos, height / -2f, yPos));
                    uvList.Add(new Vector2(xUv, 0f));

                    switch (i)
                    {
                        case 0:
                            Vector3 normal = new Vector3(cos, 0f, sin);
                            normalList.Add(normal);
                            normalList.Add(normal);
                            break;
                        case 1:
                            normalList.Add(new Vector3(0f, 1f, 0f));
                            normalList.Add(new Vector3(0f, -1f, 0f));
                            break;
                    }
                }
            }

            posList.Add(new Vector3(0, height / 2f, 0));
            posList.Add(new Vector3(0, height / -2f, 0));
            uvList.Add(new Vector2(0.5f, 0f));
            uvList.Add(new Vector2(0.5f, 1f));
            normalList.Add(new Vector3(0f, 1f, 0f));
            normalList.Add(new Vector3(0f, -1f, 0f));

            int viewVertexCount = (segment + 1) * 2;
            for (int i = 0; i < segment; i++)
            {
                int index = i * 2;
                int vi1 = index;
                int vi2 = index + 1;
                int vi3 = (index + 2) % viewVertexCount;
                int vi4 = (index + 3) % viewVertexCount;
                indexList.Add(vi1);
                indexList.Add(vi3);
                indexList.Add(vi2);

                indexList.Add(vi4);
                indexList.Add(vi2);
                indexList.Add(vi3);
            }

            for (int i = 0; i < viewVertexCount; i += 2)
            {
                indexList.Add(posList.Count - 2);
                indexList.Add((i + 2) % viewVertexCount + viewVertexCount);
                indexList.Add(i + viewVertexCount);
            }

            for (int i = 1; i < viewVertexCount; i += 2)
            {
                indexList.Add(posList.Count - 1);
                indexList.Add(i + viewVertexCount);
                indexList.Add((i + 2) % viewVertexCount + viewVertexCount);
            }

            resultMesh.vertices = posList.ToArray();
            resultMesh.uv = uvList.ToArray();
            resultMesh.normals = normalList.ToArray();
            resultMesh.triangles = indexList.ToArray();

            return resultMesh;
        }
    }
}
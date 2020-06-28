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
            var resultMesh = new Mesh();

            var posList = new List<Vector3>();
            var uvList = new List<Vector2>();
            var normalList = new List<Vector3>();
            var indexList = new List<int>();

            for (var j = 0; j < 2; j++)
            {
                for (var i = 0; i < segment + 1; i++)
                {
                    var xUv = (float) i / segment;
                    var radian = xUv * Mathf.PI * 2f;

                    var cos = Mathf.Cos(radian);
                    var sin = Mathf.Sin(radian);
                    var xPos = cos * radius;
                    var yPos = sin * radius;
                    posList.Add(new Vector3(xPos, height / 2f, yPos));
                    uvList.Add(new Vector2(xUv, 1f));
                    posList.Add(new Vector3(xPos, height / -2f, yPos));
                    uvList.Add(new Vector2(xUv, 0f));

                    switch (j)
                    {
                        case 0:
                            var normal = new Vector3(cos, 0f, sin);
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

            var viewVertexCount = (segment + 1) * 2;
            for (var i = 0; i < segment; i++)
            {
                var index = i * 2;
                var vi1 = index;
                var vi2 = index + 1;
                var vi3 = (index + 2) % viewVertexCount;
                var vi4 = (index + 3) % viewVertexCount;
                indexList.Add(vi1);
                indexList.Add(vi3);
                indexList.Add(vi2);

                indexList.Add(vi4);
                indexList.Add(vi2);
                indexList.Add(vi3);
            }

            for (var i = 0; i < viewVertexCount; i += 2)
            {
                indexList.Add(posList.Count - 2);
                indexList.Add((i + 2) % viewVertexCount + viewVertexCount);
                indexList.Add(i + viewVertexCount);
            }

            for (var i = 1; i < viewVertexCount; i += 2)
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
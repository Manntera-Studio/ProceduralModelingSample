using OGL.ProceduralModelingKit;
using UnityEngine;

namespace ProceduralModelSample._001_Quad
{
    public class Sample : ProceduralModelBase
    {
        [SerializeField] private float sideLength = 1;

        protected override Mesh CreateMesh()
        {
            float sideHalfLength = sideLength / 2;

            Mesh resultMesh = new Mesh();

            Vector3[] posList =
            {
                new Vector3(-sideHalfLength, sideHalfLength, 0.0f),
                new Vector3(sideHalfLength, sideHalfLength, 0.0f),
                new Vector3(sideHalfLength, -sideHalfLength, 0.0f),
                new Vector3(-sideHalfLength, -sideHalfLength, 0.0f),
            };
            Vector2[] uvList =
            {
                new Vector2(0.0f, 1.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(0.0f, 0.0f),
            };
            Vector3[] normalList =
            {
                new Vector3(0.0f, 0.0f, -1.0f),
                new Vector3(0.0f, 0.0f, -1.0f),
                new Vector3(0.0f, 0.0f, -1.0f),
                new Vector3(0.0f, 0.0f, -1.0f),
            };
            int[] indexList =
            {
                0, 1, 2,
                2, 3, 0,
            };

            resultMesh.vertices = posList;
            resultMesh.uv = uvList;
            resultMesh.normals = normalList;
            resultMesh.triangles = indexList;
            resultMesh.RecalculateBounds();

            return resultMesh;
        }
    }
}
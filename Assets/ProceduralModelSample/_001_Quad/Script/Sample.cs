using OGL.ProceduralModelingKit;
using UnityEngine;

namespace ProceduralModelSample._001_Quad
{
    public class Sample : ProceduralModelBase
    {
        [SerializeField] private float sideLength;

        protected override Mesh CreateMesh()
        {
            var sideHalfLength = sideLength / 2;
            var resultMesh = new Mesh();

            var posList = new Vector3[]
            {
                new Vector3(-sideHalfLength, sideHalfLength, 0.0f),
                new Vector3(sideHalfLength, sideHalfLength, 0.0f),
                new Vector3(sideHalfLength, -sideHalfLength, 0.0f),
                new Vector3(-sideHalfLength, -sideHalfLength, 0.0f),
            };
            var uvList = new Vector2[]
            {
                new Vector2(0.0f, 0.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(0.0f, 1.0f),
            };
            var normalList = new Vector3[]
            {
                new Vector3(0.0f, 0.0f, -1.0f),
                new Vector3(0.0f, 0.0f, -1.0f),
                new Vector3(0.0f, 0.0f, -1.0f),
                new Vector3(0.0f, 0.0f, -1.0f),
            };
            var indexList = new int[]
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
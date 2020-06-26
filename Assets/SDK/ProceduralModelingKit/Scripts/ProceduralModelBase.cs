using UnityEngine;

namespace OGL.ProceduralModelingKit
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

    public abstract class ProceduralModelBase : MonoBehaviour
    {
        private MeshFilter MeshFilterComponent
        {
            get
            {
                if (meshFilterComponent == null)
                {
                    meshFilterComponent = GetComponent<MeshFilter>();
                }

                return meshFilterComponent;
            }
        }

        private MeshRenderer MeshRendererComponent
        {
            get
            {
                if (meshRendererComponent == null)
                {
                    meshRendererComponent = GetComponent<MeshRenderer>();
                }

                return meshRendererComponent;
            }
        }

        [SerializeField] private MeshFilter meshFilterComponent;
        [SerializeField] private MeshRenderer meshRendererComponent;

        protected abstract Mesh CreateMesh();
    }
}
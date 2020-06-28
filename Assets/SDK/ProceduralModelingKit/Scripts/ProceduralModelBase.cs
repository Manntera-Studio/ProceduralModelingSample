using UnityEngine;

namespace OGL.ProceduralModelingKit
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(ProceduralModelBuilder))]
    public abstract class ProceduralModelBase : MonoBehaviour
    {
        public bool ExistsMaterial => material;

        private MeshRenderer MeshRendererComponent
        {
            get
            {
                if (_meshRendererComponent == null)
                {
                    _meshRendererComponent = GetComponent<MeshRenderer>();
                }

                return _meshRendererComponent;
            }
        }

        private MeshFilter MeshFilterComponent
        {
            get
            {
                if (_meshFilterComponent == null)
                {
                    _meshFilterComponent = GetComponent<MeshFilter>();
                }

                return _meshFilterComponent;
            }
        }

        private MeshRenderer _meshRendererComponent;
        private MeshFilter _meshFilterComponent;

        [SerializeField] private Material material = null;

        private void Start()
        {
            BuildRenderer();
        }

        private void OnDestroy()
        {
            DestroyMesh();
        }

        public void BuildRenderer()
        {
            if (!material)
            {
                Debug.LogError(name + "にマテリアルが設定されていません。");
                return;
            }

            MeshRendererComponent.sharedMaterial = material;

            DestroyMesh();
            MeshFilterComponent.sharedMesh = CreateMesh();
        }

        private void DestroyMesh()
        {
            Mesh mesh = MeshFilterComponent.sharedMesh;
            if (!mesh) return;
            if (Application.isPlaying)
            {
                Destroy(mesh);
            }
            else
            {
                DestroyImmediate(mesh);
            }
        }

        protected abstract Mesh CreateMesh();
    }
}
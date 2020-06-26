using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OGL.ProceduralModelingKit
{
    /// <summary>
    /// abstractしたClassをCustomEditor出来ないので苦肉の策で作成 
    /// </summary>
    public class ProceduralModelBuilder : MonoBehaviour
    {
        private ProceduralModelBase ProceduralModel
        {
            get
            {
                if (proceduralModelBase == null)
                {
                    proceduralModelBase = GetComponent<ProceduralModelBase>();
                }

                return proceduralModelBase;
            }
        }

        [SerializeField, HideInInspector] private ProceduralModelBase proceduralModelBase;

        public void Build()
        {
            ProceduralModel.BuildRenderer();
        }

        public bool ExistsMaterial => ProceduralModel.ExistsMaterial;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(ProceduralModelBuilder))]
    public class ProceduralModelBaseEditor : Editor
    {
        private ProceduralModelBuilder _builder;

        private void OnEnable()
        {
            _builder = (ProceduralModelBuilder) target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.OnInspectorGUI();

            if (!_builder.ExistsMaterial)
            {
                EditorGUILayout.HelpBox("マテリアルが設定されていません。", MessageType.Error);
            }
            else
            {
                if (GUILayout.Button("BuildRenderer"))
                {
                    _builder.Build();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
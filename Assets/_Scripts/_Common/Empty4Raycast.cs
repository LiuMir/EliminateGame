#if UNITY_EDITOR
using UnityEditor;
#endif
namespace UnityEngine.UI
{
    /// <summary>
    /// 代替空的Image接受点击
    /// </summary>
    public class Empty4Raycast : Graphic, ICanvasRaycastFilter
    {
        protected Empty4Raycast()
        {
            useLegacyMeshGeneration = false;
        }

        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            toFill.Clear();
        }

        public override void SetMaterialDirty() { }
        public override void SetVerticesDirty() { }

        public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
        {
            return true;
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(Empty4Raycast))]
        class SelfEditor : Editor
        {
            public override void OnInspectorGUI()
            {

            }
        }
#endif
    }
}
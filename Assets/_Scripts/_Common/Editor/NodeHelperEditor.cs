using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NodeHelper))]
public class NodeHelperEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("序列化rd_节点"))
        {
            NodeHelper nodeHelper = (NodeHelper)target;
            nodeHelper.RefreshRdNodeList();
            serializedObject.ApplyModifiedProperties();
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}

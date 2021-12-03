using UnityEditor;

[CustomEditor(typeof(TransformPosMark))]
public class TransformPosMarkEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TransformPosMark transformPosMark = (TransformPosMark)target;
        transformPosMark.ChangeMarkLocalPosition(transformPosMark.transform.localPosition);
        serializedObject.ApplyModifiedProperties();
    }
}

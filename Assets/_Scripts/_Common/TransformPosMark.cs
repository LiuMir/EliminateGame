using UnityEngine;

[DisallowMultipleComponent]
public class TransformPosMark : MonoBehaviour
{
    public Vector3 MarkLocalPosition;
    public Vector3 MaxLocalPosition = new Vector3(0, 9999999, 0);

    // 提供给OnInspectorGUI 调用
    public void ChangeMarkLocalPosition(Vector3 pos)
    {
        MarkLocalPosition = pos;
    }
}

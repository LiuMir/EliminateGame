using UnityEngine;

public class NodeHelper : MonoBehaviour
{
    public bool isAddTransformPosMark = false;

    [SerializeField]
    private SerializableStringGameObjectDictionary nodes = new SerializableStringGameObjectDictionary();

    public GameObject GetNode(string nodeName)
    {
        nodes.TryGetValue(nodeName, out GameObject node);
        return node;
    }

    public void RefreshRdNodeList()
    {
        nodes.Clear();
        nodes.ClearList();
        FindRdNode(this.transform);
    }

    private void FindRdNode(Transform parentNode)
    {
        int childCount = parentNode.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform node = parentNode.GetChild(i);
            if (nodes.ContainsKey(node.name))
            {
                Debug.LogError(parentNode.name + "下有重复的key: " + node.name);
            }
            else
            {
                if (node.name.StartsWith("rd_"))
                {
                    if (isAddTransformPosMark)
                    {
                        node.gameObject.AddComponent<TransformPosMark>();
                    }
                    nodes.AddKeyAndValue(node.name, node.gameObject);
                }
            }
            if (node.GetComponent<NodeHelper>() != null || node.GetComponent("LuaMono") != null)
            {
                continue;
            }
            FindRdNode(node);
        }
    }
}

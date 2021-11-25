using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject WindowUIRoot;
    public GameObject PoolUIRoot;
    private void Awake()
    {
        UIMgr.Instance.SetPoolRoot(PoolUIRoot);
       UIMgr.Instance.AddCreateUIMethod(UIWindowLayer.WindowLayer, new UIWindowLayerContent(WindowUIRoot));
        UIMgr.Instance.AddCreateUIMethod(UIWindowLayer.PopLayer, new UIPopLayerContent());
    }
}

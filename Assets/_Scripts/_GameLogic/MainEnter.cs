using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnter : MonoBehaviour
{
    private GameObject UIRoot;
    private GameObject WindowUIRoot;
    private GameObject PoolUIRoot;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        UIRoot = GameObject.Find("UIRoot");
        WindowUIRoot = UIRoot.transform.Find("MainUICanvas").gameObject;
        PoolUIRoot = UIRoot.transform.Find("UIPoolRoot").gameObject;
        UIMgr.Instance.SetPoolRoot(PoolUIRoot);
        UIMgr.Instance.AddCreateUIMethod(UIWindowLayer.WindowLayer, new UIWindowLayerContent(WindowUIRoot));
        UIMgr.Instance.AddCreateUIMethod(UIWindowLayer.PopLayer, new UIPopLayerContent());
    }

    private void Start()
    {
        UIMgr.Instance.OnShowUI("MainUI");
    }

}

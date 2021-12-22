using System;
using UnityEngine;

public class MainEnter : MonoBehaviour
{
    private GameObject UIRoot;
    private GameObject WindowUIRoot;
    private GameObject PoolUIRoot;
    public  Camera UICamera;
    public static event Action UpdateEvent;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        UIRoot = GameObject.Find("UIRoot");
        WindowUIRoot = UIRoot.transform.Find("MainUICanvas").gameObject;
        PoolUIRoot = UIRoot.transform.Find("UIPoolRoot").gameObject;
        UIMgr.Instance.UICamera = UICamera;
        UIMgr.Instance.SetPoolRoot(PoolUIRoot);
        UIMgr.Instance.AddCreateUIMethod(UIWindowLayer.WindowLayer, new UIWindowLayerContent(WindowUIRoot));
        UIMgr.Instance.AddCreateUIMethod(UIWindowLayer.PopLayer, new UIPopLayerContent());
    }

    private void Start()
    {
        UIMgr.Instance.OnShowUI("MainUI");
    }

    private void Update()
    {
        UpdateEvent?.Invoke();
    }

}

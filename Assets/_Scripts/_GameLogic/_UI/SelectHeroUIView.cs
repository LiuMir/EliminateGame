using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHeroUIView : BaseUI
{
    private Button btnClose;
    private NodeHelper rootNodeHelper;
    public override void Awake()
    {
        base.Awake();
        rootNodeHelper = viewMono.GetComponent<NodeHelper>();
        btnClose = rootNodeHelper.GetNode("rd_BtnClose").GetComponent<Button>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        btnClose.onClick.AddListener(CloseSelf);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        btnClose.onClick.RemoveListener(CloseSelf);
    }

    private void CloseSelf()
    {
        UIMgr.Instance.OnCloseUI(viewMono);
    }

}

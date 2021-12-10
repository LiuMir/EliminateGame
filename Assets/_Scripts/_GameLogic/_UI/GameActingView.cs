using UnityEngine;
using UnityEngine.UI;

public class GameActingView:BaseUI
{
    private NodeHelper rootNodeHelper;
    public override void Awake()
    {
        base.Awake();
        rootNodeHelper = viewMono.GetComponent<NodeHelper>();
        UIEventMgr.AddListener<Button>(rootNodeHelper.GetNode("rd_BtnQuit"), "onClick", (btn) => {
            btn.onClick.AddListener(CloseSelf);
        });
        UIEventMgr.AddListener<Button>(rootNodeHelper.GetNode("rd_BtnAuto"), "onClick", (btn) =>
        {
            btn.onClick.AddListener(AutoAtk);
        });
        UIEventMgr.AddListener<Button>(rootNodeHelper.GetNode("rd_BtnSpeedUp"), "onClick", (btn) =>
        {
            btn.onClick.AddListener(SpeedUpAtk);
        });
        UIEventMgr.AddListener<Button>(rootNodeHelper.GetNode("rd_BtnAtk"), "onClick", (btn) =>
        {
            btn.onClick.AddListener(Atk2Obj);
        });
    }
    
    private void CloseSelf()
    {
        UIMgr.Instance.OnCloseUI(viewMono);
        BattleSceneMgr.Instance.RemoveBattleScene();
    }

    // 自动攻击
    private void AutoAtk()
    {
        Debug.LogError("AutoAtk");
    }

    // 加速攻击
    private void SpeedUpAtk()
    {
        Debug.LogError("SpeedUpAtk");
    }

    // 主动攻击
    private void Atk2Obj()
    {
        Debug.LogError("Atk2Obj");
    }
}

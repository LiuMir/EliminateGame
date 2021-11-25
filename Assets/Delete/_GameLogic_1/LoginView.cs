using UnityEngine.UI;

public class LoginViewArgs
{

}

public class LoginView:BaseUI
{
    public override void Awake()
    {
        base.Awake();
        Button btn = this.viewMono.transform.Find("Bottom/AllBtns/Button").GetComponent<Button>();
        Button closeBtn = this.viewMono.transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(ShowMainView);
        closeBtn.onClick.AddListener(CloseSelf);
    }

    private void ShowMainView()
    {
        UIMgr.Instance.OnShowUI("MainUI", new MainViewArgs { Count = 17878, UIName = "LoginView" });
    }

    public void CloseSelf()
    {
        UIMgr.Instance.OnCloseUI(this.viewMono);
    }
}
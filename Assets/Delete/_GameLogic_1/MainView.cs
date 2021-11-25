using UnityEngine;
using UnityEngine.UI;

public class MainViewArgs : BaseArgs
{
    public int Count;
    public string UIName;

    public override string ToString()
    {
        return $"Count:{Count}, UIName{UIName}";
    }
}

public class MainView : BaseUI
{
    public Button CloseBtn;
    public Button TaskBtn;
    private MainViewArgs viewArgs;

    public override void Awake()
    {
        base.Awake();
        Transform btnObj = viewMono.gameObject.transform.Find("Top/Btn_CloseSelf");
        Transform taskObj = viewMono.gameObject.transform.Find("Bottom/AllBtns/Btn_Task");
        CloseBtn = btnObj.GetComponent<Button>();
        TaskBtn = taskObj.GetComponent<Button>();
        CloseBtn.onClick.AddListener(CloseSelf);
        TaskBtn.onClick.AddListener(OpenLogin);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.LogError("MainView OnEnable");
    }

    public override void OnDisable()
    {
        base.OnDisable();
        Debug.LogError("MainView OnDisable");
    }

    public override void Show(BaseArgs Args = null)
    {
        viewArgs = Args as MainViewArgs;
        Debug.LogError(viewArgs.ToString());
    }

    public override void Close()
    {
        base.Close();
        Debug.LogError("MainView Close");
    }

    private void CloseSelf()
    {
        UIMgr.Instance.OnCloseUI(viewMono);
    }

    private void OpenLogin()
    {
        UIMgr.Instance.OnShowUI("LoginUI");
    }

}

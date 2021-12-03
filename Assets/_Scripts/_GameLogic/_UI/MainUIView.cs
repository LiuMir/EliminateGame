using UnityEngine;
using UnityEngine.UI;

public class MainUIView : BaseUI
{
    private Button btnStartGame;
    public override void Awake()
    {
        base.Awake();
        btnStartGame = this.viewMono.transform.Find("BtnStartGame").GetComponent<Button>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        btnStartGame.onClick.AddListener(StartGame);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        btnStartGame.onClick.RemoveListener(StartGame);
        Debug.LogError("MainUIView OnDisable");
    }

    public override void Show(BaseArgs Args = null)
    {
        base.Show(Args);
    }

    private void StartGame()
    {
        UIMgr.Instance.OnShowUI("SelectHeroUI");
    }

    public override void Close()
    {
        base.Close();
        Debug.LogError("MainUIView Close");
    }

}

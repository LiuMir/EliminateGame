using UnityEngine;
using UnityEngine.UI;

public class GameEnter : MonoBehaviour
{
    public Button BtnStartGame;

    private void Awake()
    {
        BtnStartGame.onClick.AddListener(() => {
            StartGame();
        });
    }


    private void StartGame()
    {
        GameMapMgr.Instance.Init();
    }

}

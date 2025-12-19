using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;

    private void Update()
    {
        startPanel.SetActive(GameManager.Instance.CurrentState == GameState.MainMenu);
        gameOverPanel.SetActive(GameManager.Instance.CurrentState == GameState.GameOver);
    }


    public void OnStartButton()
    {
        GameManager.Instance.StartGame();
    }

    public void OnRestartButton()
    {
        GameManager.Instance.RestartGame();
    }


}

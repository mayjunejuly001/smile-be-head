using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        SetState(GameState.MainMenu);
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                // Handle main menu state
                break;
            case GameState.Playing:
                // Handle playing state
                break;
            case GameState.Paused:
                // Handle paused state
                break;
            case GameState.GameOver:   
                // Handle game over state
                break;

        }
    }

    public void StartGame()
    {
        SetState(GameState.Playing);

    }

    public void PauseGame()
    {
        SetState(GameState.Paused);
    }

    public void GameOver()
    {
        SetState(GameState.GameOver);
    }

}

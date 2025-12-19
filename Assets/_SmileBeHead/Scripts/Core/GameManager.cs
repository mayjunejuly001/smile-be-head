using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; }

    [Header("Scene Ref")]
    [SerializeField] private GameObject enemyWaveSpawner;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void OnEnable()
    {
        if (player != null)
        {
            player.GetComponent<PlayerHealth>().OnPlayerDeath += GameOver;

        }
    }
    private void OnDisable()
    {   if(player  != null)
        {
            player.GetComponent<PlayerHealth>().OnPlayerDeath -= GameOver;

        }
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
                HandleMainMenu();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.GameOver:   
                HandleGameOver();
                break;

        }
    }

    private void HandleMainMenu()
    {
        Time.timeScale = 0f;
        enemyWaveSpawner.SetActive(false);
        player.SetActive(false);
    }



    private void HandlePlaying()
    {
        Time.timeScale = 1f;
        
        enemyWaveSpawner.SetActive(true);
        player.SetActive(true);

    }

    private void HandleGameOver()
    {
        Time.timeScale = 0f;
        enemyWaveSpawner.SetActive(false);
    }

    public void StartGame()
    {
        SetState(GameState.Playing);
    }

    public void GameOver()
    {
        SetState(GameState.GameOver);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

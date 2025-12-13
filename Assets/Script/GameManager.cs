using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Title,
    InGame,
    GameOver
}

public class GameManager : MonoBehaviour
{

    public float AutoDropTime => autoDropTime;

    public static GameManager Instance;

    [SerializeField] GameObject[] tetrominoPrefabs;
    [SerializeField] Transform tetrominoSpawnerTransform;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] float autoDropTime = 1.5f;

    public int Score { get; private set; } = 0;
    private SceneLoader loader;

    public GameState State { get; private set; }

    void Awake()
    {
        Instance = this;
        SpawnTetromino();
        Time.timeScale = 1f;
        DontDestroyOnLoad(gameObject);
        State = GameState.InGame;
    }

    public void SpawnTetromino() => Instantiate(tetrominoPrefabs[Random.Range(0, tetrominoPrefabs.Length)], tetrominoSpawnerTransform.position, Quaternion.identity);

    public void GameOver()
    {
        Time.timeScale = 0f;
        PlayerInput.DisableAllInputs();
        SceneManager.LoadScene("GameOver");
        State = GameState.GameOver;
    }

    public void OnTryAgainButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void AddScore()
    {
        Score++;
    }

    private void Update()
    {
        switch (State)
        {
            case GameState.GameOver:
                if (Input.GetKeyUp(KeyCode.K))
                {
                    State = GameState.Title;
                    SceneManager.LoadScene("Title");
                    Score = 0;
                }
                break;
            case GameState.Title:
                if (Input.GetKeyUp(KeyCode.K))
                {
                    State = GameState.InGame;
                    SceneManager.LoadScene("InGame");
                }
                break;
        }
    }
}
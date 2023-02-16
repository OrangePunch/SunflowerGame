using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private GameSession _gameSession;

    private void Awake()
    {
        _gameSession = FindObjectOfType<GameSession>().GetComponent<GameSession>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGameMenu();
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Quit();
        }
    }

    private void StartGameMenu()
    {
        SceneManager.LoadScene(_sceneName);
        _gameSession.Data.Enemies = 0;
        _gameSession.Data.Seeds = 0;
    }

    private void Quit()
    {
        Application.Quit();
    }
}

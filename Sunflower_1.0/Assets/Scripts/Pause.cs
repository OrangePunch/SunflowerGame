using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public float timer;
    public bool isPause = false;
    public bool guiPause;

    [SerializeField] private TextMeshProUGUI _pauseText;
    [SerializeField] private TextMeshProUGUI _exitPauseText;
    [SerializeField] private TextMeshProUGUI _exitToMenuText;
    [SerializeField] private GameObject _woodFirst;
    [SerializeField] private GameObject _woodSecond;

    private PlayerMotor _playerMotor;

    private void Start()
    {
        _playerMotor = FindObjectOfType<PlayerMotor>().GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        Time.timeScale = timer;

        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            isPause = true;
            ActivatePauseMenu();
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            isPause = false;
            ExitPauseMenu();
            Cursor.visible = false;
        }

        if (isPause == true && !_playerMotor._gameEnded)
        {
            timer = 0;
            guiPause = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (isPause == false && !_playerMotor._gameEnded)
        {
            timer = 1f;
            guiPause = false;
        }

        if (_playerMotor._gameEnded)
        {
            timer = 0;
            guiPause = true;
        }
    }
    public void ActivatePauseMenu()
    {
        _pauseText.gameObject.SetActive(true);
        _exitPauseText.gameObject.SetActive(true);
        _exitToMenuText.gameObject.SetActive(true);
        _woodFirst.gameObject.SetActive(true);
        _woodSecond.gameObject.SetActive(true);
    }

    public void ExitPauseMenu()
    {
        _pauseText.gameObject.SetActive(false);
        _exitPauseText.gameObject.SetActive(false);
        _exitToMenuText.gameObject.SetActive(false);
        _woodFirst.gameObject.SetActive(false);
        _woodSecond.gameObject.SetActive(false);
    }
}
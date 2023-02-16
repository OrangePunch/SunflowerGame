using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float _jumpHeight;
    [SerializeField] private TextMeshProUGUI _gameEndText;
    [SerializeField] private TextMeshProUGUI _totalScoreText;
    [SerializeField] private GameObject _gameEndImage;

    public float _speed;
    public bool _gameEnded = false;
    public bool _isGrounded;

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private float _gravity = -9.8f;
    private GameSession _gameSession;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _gameSession = FindObjectOfType<GameSession>().GetComponent<GameSession>();
    }

    private void Update()
    {
        _isGrounded = _controller.isGrounded;

        if (_gameEnded && Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);

        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }

        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3f * _gravity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _totalScoreText.text = "Total seeds: " + _gameSession.Data.Seeds;

            _gameEndImage.gameObject.SetActive(true);
            _gameEndText.gameObject.SetActive(true);
            _totalScoreText.gameObject.SetActive(true);
            _gameEnded = true;
        }
    }
}

using UnityEngine;

public class PlayerInputAct : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;
    private PlayerMotor _motor;
    private PlayerLook _look;
    private GameManager _gameManager;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
        _onFoot.Jump.performed += ctx => _motor.Jump();
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void Update()
    {
        _gameManager.UpdateSeedsAmount();
        _gameManager.UpdateEnemiesAmount();

        if (_motor._speed == 8 && _motor._isGrounded)
        {
            _particles.Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _motor._speed += 4;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _particles.Stop();
            _motor._speed -= 4;
        }
    }

    private void FixedUpdate()
    {
        _motor.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _look.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFoot.Enable();
    }

    private void OnDisable()
    {
        _onFoot.Disable();
    }
}

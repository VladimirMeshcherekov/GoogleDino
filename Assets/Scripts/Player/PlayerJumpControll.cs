using UnityEngine;
[RequireComponent(typeof(PlayerAnimations), typeof(PlayerRun))]
public class PlayerJumpControll : MonoBehaviour
{
    private PlayerInput _playerInput;
    private IAnimatePlayer _animatePlayer;

    private bool _isPlayerOnAGround = true;
    private bool _isPlayerAlive = true;
    private PlayerRun _playerRun;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Jump.performed += ctx => Jump();
        _playerRun = GetComponent<PlayerRun>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerRun.PlayerDie += PlayerDie;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerRun.PlayerDie -= PlayerDie;
    }

    private void Start()
    {
        _animatePlayer = GetComponent<PlayerAnimations>();
    }

    private void OnCollisionEnter2D(Collision2D enterCollision)
    {
        if (enterCollision.gameObject.TryGetComponent(out Ground ground))
        {
            _isPlayerOnAGround = true;
            _animatePlayer.SetRunAnimation();
        }
    }

    private void OnCollisionExit2D(Collision2D enterCollision)
    {
        if (enterCollision.gameObject.TryGetComponent(out Ground ground))
        {
            _isPlayerOnAGround = false;
        }
    }

    private void Jump()
    {
        if (_isPlayerOnAGround && _isPlayerAlive)
        {
            _animatePlayer.SetJumpAnimation();
        }
    }

    private void PlayerDie()
    {
        _isPlayerAlive = false;
    }
    
}
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerAnimations), typeof(ISoundPlayer), typeof(IAnimatePlayer))]
public class PlayerJumpControll : MonoBehaviour
{
    private PlayerInput _playerInput;
    private IAnimatePlayer _animatePlayer;
    private ISoundPlayer _soundPlayer;

    private bool _isPlayerOnAGround = true;
    private bool _isPlayerAlive = true;
    [Inject] private PlayerRun _playerRun;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Jump.performed += ctx => Jump();
        _soundPlayer = GetComponent<ISoundPlayer>();
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
        if (enterCollision.gameObject.TryGetComponent(out GroundComponent ground))
        {
            _isPlayerOnAGround = true;
            _animatePlayer.SetRunAnimation();
            _soundPlayer.PlayLandSound();
        }
    }

    private void OnCollisionExit2D(Collision2D enterCollision)
    {
        if (enterCollision.gameObject.TryGetComponent(out GroundComponent ground))
        {
            _isPlayerOnAGround = false;
        }
    }

    private void Jump()
    {
        if (_isPlayerOnAGround && _isPlayerAlive)
        {
            _animatePlayer.SetJumpAnimation();
            _soundPlayer.PlayJumpSound();
        }
    }

    private void PlayerDie()
    {
        _isPlayerAlive = false;
    }
}
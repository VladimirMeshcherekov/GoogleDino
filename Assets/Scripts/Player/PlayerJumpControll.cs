using System;
using UnityEngine;

public class PlayerJumpControll : MonoBehaviour
{
    private PlayerInput _playerInput;
    private IJumpPlayer _jumpPlayer;

    private bool _isPlayerAbleToJump = true;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _jumpPlayer = GetComponent<PlayerJumpAnimation>();
    }

    private void OnCollisionEnter2D(Collision2D enterCollision)
    {
        if (enterCollision.gameObject.TryGetComponent(out Ground ground))
        {
            _isPlayerAbleToJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D enterCollision)
    {
        if (enterCollision.gameObject.TryGetComponent(out Ground ground))
        {
            _isPlayerAbleToJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _jumpPlayer.Die();
    }


    void Jump()
    {
        if (_isPlayerAbleToJump)
        {
            _jumpPlayer.Jump();
        }
    }
}
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private PlayerInput _playerInput;
    private IJumpPlayer _jumpPlayer;
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

    void Jump()
    {
      
    }
    
}

using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour, IJumpPlayer
{
    [SerializeField] private Transform endJumpPoint;
    [SerializeField] private int jumpPower;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float fallAcceleration;
    private const int JumpNum = 1;
    [Space]
    [SerializeField] private AnimationClip playerJump, playerRun, playerDie;
    
    private Animator _playerAnimator;


    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _playerAnimator.Play(playerJump.name);
        Vector3 positionBeforeJump = transform.position;
        transform.DOJump(endJumpPoint.transform.position, jumpPower, JumpNum, jumpDuration);
        transform.DOJump(positionBeforeJump, jumpPower, JumpNum, jumpDuration / fallAcceleration)
            .SetDelay(jumpDuration);
    }

    public void Die()
    {
        _playerAnimator.Play(playerDie.name);
    }

    public void Run()
    {
        _playerAnimator.Play(playerRun.name);
    }
}

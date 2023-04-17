using DG.Tweening;
using UnityEngine;

public class PlayerJumpAnimation : MonoBehaviour
{
    [SerializeField] private Transform endJumpPoint;
    [SerializeField] private int jumpPower;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float fallAcceleration;
    private const int _jumpNum = 1;

    public void Jump()
    {
        Vector3 positionBeforeJump = transform.position;
        transform.DOJump(endJumpPoint.transform.position, jumpPower, _jumpNum, jumpDuration);
        transform.DOJump(positionBeforeJump, jumpPower, _jumpNum, jumpDuration/fallAcceleration).SetDelay(jumpDuration);
    }


}

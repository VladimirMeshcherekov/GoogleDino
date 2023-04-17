using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerJumpAnimation : MonoBehaviour, IJumpPlayer
{
    [SerializeField] private Transform endJumpPoint;
    [SerializeField] private int jumpPower;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float fallAcceleration;
    private const int _jumpNum = 1;
    
    [Space(10)]
    private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private Sprite playerDieSprite;

    [Space(10)] [SerializeField] private float timeBetweenSpriteChangesInSeconds;
    [SerializeField] private List<Sprite> playerRunSprites = new List<Sprite>();
    private int _currentSpriteInRunningAnimation;
    private float _timeLeft;
    
    private void Start()
    {
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Jump()
    {
        Vector3 positionBeforeJump = transform.position;
        transform.DOJump(endJumpPoint.transform.position, jumpPower, _jumpNum, jumpDuration);
        transform.DOJump(positionBeforeJump, jumpPower, _jumpNum, jumpDuration/fallAcceleration).SetDelay(jumpDuration);
    }

    public void Die()
    {
        _playerSpriteRenderer.sprite = playerDieSprite;
    }
    
}

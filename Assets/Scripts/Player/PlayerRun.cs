using System;
using UnityEngine;

[RequireComponent(typeof(IAnimatePlayer), typeof(ISoundPlayer))]
public class PlayerRun : MonoBehaviour
{
    public delegate void Player();
    public event Player PlayerDie;
    public event Player PlayerAddScore;

    private IAnimatePlayer _animatePlayer;
    private ISoundPlayer _soundPlayer;

    private void Start()
    {
        _animatePlayer = GetComponent<IAnimatePlayer>();
        _soundPlayer = GetComponent<ISoundPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D enterCollider2D)
    {
        if (enterCollider2D.gameObject.TryGetComponent(out CactusMove cactusMove))
        {
            PlayerDie?.Invoke();
            _animatePlayer.SetDieAnimation();
            _soundPlayer.PlayDieSound();
        }

        if (enterCollider2D.gameObject.TryGetComponent(out AddScoreToPlayerComponent addScoreToPlayer))
        {
            PlayerAddScore?.Invoke();
        }
    }
}
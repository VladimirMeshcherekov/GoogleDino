using UnityEngine;
[RequireComponent(typeof(IAnimatePlayer))]
public class PlayerRun : MonoBehaviour
{
    public delegate void Player();
    public event Player PlayerDie;
    public event Player PlayerAddScore;
    private void OnTriggerEnter2D(Collider2D enterCollider2D)
    {
        if (enterCollider2D.gameObject.TryGetComponent(out CactusMove cactusMove))
        {
            PlayerDie?.Invoke();
            gameObject.GetComponent<IAnimatePlayer>().SetDieAnimation();
        }

        if (enterCollider2D.gameObject.TryGetComponent(out AddScoreToPlayer addScoreToPlayer))
        {
            PlayerAddScore?.Invoke();
        }
    }
}

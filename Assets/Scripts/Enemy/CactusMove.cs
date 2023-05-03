using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class CactusMove : MonoBehaviour
{
    private Rigidbody2D _thisEnemyRb;
    [SerializeField] private float enemyVelocity;
    
    void Start()
    {
        _thisEnemyRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _thisEnemyRb.velocity = Vector2.left * enemyVelocity;
    }
}

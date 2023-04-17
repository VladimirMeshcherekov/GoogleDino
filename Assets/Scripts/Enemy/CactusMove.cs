using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class CactusMove : MonoBehaviour
{
    private Rigidbody2D _enemyRb;
    [SerializeField] private float enemyVelocity;
    
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _enemyRb.velocity = Vector2.left * enemyVelocity;
    }
}

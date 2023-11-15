using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 20;
    [SerializeField] 
    private int _damage = 20;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * _speed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BaseEnemy>())
        {
            other.GetComponent<Health>()?.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void PrepareKnife(float speed, int damage)
    {
        _speed = speed;
        _damage = damage;
    }
}

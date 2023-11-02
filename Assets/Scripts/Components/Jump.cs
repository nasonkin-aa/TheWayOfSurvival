using UnityEngine;

[RequireComponent(typeof(Move))]
public class Jump : MonoBehaviour
{
    private Move _move;
    [SerializeField]
    protected float _jumpForce = 15f;
    public void Awake()
    {
        _move = GetComponent<Move>();
    }

    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        rb.AddForce(Vector2.up * _jumpForce);
    }
    public void OnEnable()
    {
        _move.OnMove += Move;
    }
    public void OnDisable()
    {   
        _move.OnMove -= Move;
    }
}

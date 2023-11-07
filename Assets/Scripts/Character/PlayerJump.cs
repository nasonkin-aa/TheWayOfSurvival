using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private readonly int _jumpConstanta = 60;
    [SerializeField]
    public float jumpForce = 10;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = transform.GetComponent<Rigidbody2D>();
    }
    private void Jump()
    {
        if (GroundChecker.IsPayerOnTheGround)
        {
            _rb.AddForce(Vector2.up * (jumpForce * _jumpConstanta));
        }

    }
    public void OnEnable()
    {
        PlayerInput.OnPlayerJump += Jump;
    }
    public void OnDisable()
    {
        PlayerInput.OnPlayerJump -= Jump;
    }
}

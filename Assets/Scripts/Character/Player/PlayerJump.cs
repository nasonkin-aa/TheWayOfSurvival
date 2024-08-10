using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private readonly int _jumpConstanta = 60;
    [SerializeField]
    public float jumpForce = 10;
    private Rigidbody2D _rb;
    private float _disableCollisionTime = 0.4f;
    private readonly int _platformlayer =  13;
    private Collider2D Collider => GetComponent<Collider2D>();


    void Start()
    {
        _rb = transform.GetComponent<Rigidbody2D>();
    }
    private void Jump()
    {
        var velocityY = _rb.velocity.y;
        if (GroundChecker.IsPayerOnTheGround && velocityY <= 0)
        {
            _rb.AddForce(Vector2.up * (jumpForce * _jumpConstanta));
            AudioManager.Instance.Play("PlayerJump");
        }
    }

    private void JumpDown(float verticalVelocity)
    {
        if (verticalVelocity <= 0)
            StartCoroutine(ActivateCollisionWithPlatforms());
    }

    private IEnumerator ActivateCollisionWithPlatforms()
    {
        Collider.forceReceiveLayers &= ~(1 << _platformlayer);
        yield return new WaitForSeconds(_disableCollisionTime);
        Collider.forceReceiveLayers |= (1 << _platformlayer);
    }
    public void OnEnable()
    {
        PlayerInput.OnPlayerJump += Jump;
        PlayerInput.OnPlayerMoveDown += JumpDown;
    }
    public void OnDisable()
    {
        PlayerInput.OnPlayerJump -= Jump;
        PlayerInput.OnPlayerMoveDown -= JumpDown;
    }
}

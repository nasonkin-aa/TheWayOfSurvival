using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private readonly int _jumpConstanta = 60;
    [SerializeField]
    public float _speed = 0.4f;
    [SerializeField]
    public float jumpForce = 10;
    private Rigidbody2D _rb;
    private Camera _mainCamera;
    
    private void Awake()
    {
        _mainCamera = Camera.main;  
    }
    
    void Start()
    {
        _rb = transform.GetComponent<Rigidbody2D>();
    }

    private void Move(float direction)
    {
        Vector3 newPositioin = new Vector3((direction * _speed), 0, 0);
        transform.position += newPositioin;
    }

    private void Flip(Vector3 position)
    {
        float mouseWorldPosition = (_mainCamera.ScreenToWorldPoint(position) - transform.position).normalized.x;
        var localScale = gameObject.transform.localScale;
        if ((mouseWorldPosition > 0 && localScale.x < 0) || (mouseWorldPosition < 0 && localScale.x > 0))
        {
            localScale.x = -localScale.x;                                     
            gameObject.transform.localScale = localScale;       
        }
        
    }
    private void Jump()
    {
        if (GroundChecker.IsPayerOnTheGround)
        {
            _rb.AddForce(Vector2.up * jumpForce * _jumpConstanta);
        }
        
    }
    public void OnEnable()
    {
        PlayerInput.OnPlayerMoveHorizontal += Move;
        PlayerInput.OnPlayerJump += Jump;
        PlayerInput.OnPlayerFlip += Flip;

    }
    public void OnDisable()
    {
        PlayerInput.OnPlayerMoveHorizontal -= Move;
        PlayerInput.OnPlayerJump -= Jump;
        PlayerInput.OnPlayerFlip -= Flip;
    }
}

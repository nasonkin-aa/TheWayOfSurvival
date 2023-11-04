using UnityEngine;

public class PlayerMove : MoveBase
{
    [SerializeField]
    public float _speed = 0.4f;
    private Camera _mainCamera;
    
    private void Awake()
    {
        _mainCamera = Camera.main;  
    }

    private void Move(float direction)
    {
        Vector3 newPositioin = new Vector3((direction * _speed), 0, 0);
        transform.position += newPositioin;
    }

    private void Flip(Vector3 position)
    {
        float mouseWorldPosition = (_mainCamera.ScreenToWorldPoint(position) - transform.position).normalized.x;
        Flip(mouseWorldPosition, gameObject);   
    }

    public void OnEnable()
    {
        PlayerInput.OnPlayerMoveHorizontal += Move;
        PlayerInput.OnPlayerFlip += Flip;

    }
    public void OnDisable()
    {
        PlayerInput.OnPlayerMoveHorizontal -= Move;
        PlayerInput.OnPlayerFlip -= Flip;
    }
}

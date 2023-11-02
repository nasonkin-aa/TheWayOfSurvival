using UnityEngine;


[RequireComponent(typeof(Move))]
public class Run : MonoBehaviour
{
    private float _speedScale = 2f;
    private Move _move;
    public void Awake()
    {
        _move = GetComponent<Move>();
    }
    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        rb.velocity = direction * _speedScale;
        Flip(direction.x);
    }
    
    private void Flip(float direction)
    {
        var localScale = gameObject.transform.localScale;
        
        if ((direction < 0 && localScale.x < 0) || (direction > 0 && localScale.x > 0))
        {
            localScale.x = -localScale.x;
            gameObject.transform.localScale = localScale;
        }
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

using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Jump : MonoBehaviour
{
    
    [SerializeField]
    protected float _jumpForce = 15f;
    public void Move(Rigidbody2D rb,Vector2 direction)
    {
        rb.AddForce(Vector2.up * _jumpForce);
    }
   
}

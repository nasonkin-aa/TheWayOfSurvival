using System;
using UnityEngine;


[RequireComponent(typeof(PlayerMove))]
public class PlayerInput : Singleton<PlayerInput>
{
    public static float Horizontal;
    public static float Vertical;

    public static event Action<float> OnPlayerMoveHorizontal;
    public static event Action<float> OnPlayerMoveDown;
    public static event Action OnPlayerJump;
    public static event Action<Vector3> OnPlayerAttack;
    public static event Action<Vector3> OnPlayerFlip;

    public event Action PausePressedEvent;

    private static bool IsInputBlock = false;
    private bool isFlip = false;

    private Rigidbody2D Rigidbody => gameObject.GetComponent<Rigidbody2D>();
    private Animator Animator => gameObject.GetComponent<Animator>();

    public void FixedUpdate()
    {
        if (IsInputBlock)
            return;

        Horizontal = Input.GetAxis("Horizontal");
        OnPlayerMoveHorizontal?.Invoke(Horizontal);

        Vertical = Input.GetAxis("Vertical");
        if (Vertical < 0)
            OnPlayerMoveDown?.Invoke(Vertical);

        Animator?.SetFloat("Speed", MathF.Abs(Horizontal));
        Animator?.SetFloat("yVelocity", Rigidbody.velocity.y);
        
        if (isFlip)
            Animator?.SetFloat("rawSpeed", -Horizontal);
        else
            Animator?.SetFloat("rawSpeed", Horizontal);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PausePressedEvent?.Invoke();

        if (IsInputBlock)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            OnPlayerAttack?.Invoke(Input.mousePosition);
        }

        if (Input.GetButtonDown("Jump"))
            OnPlayerJump?.Invoke();
        
        OnPlayerFlip?.Invoke(Input.mousePosition);
    }

    private void OnPause() => IsInputBlock = true;
    private void OnUnpause() => IsInputBlock = false;

    private void Flip()
    {
        isFlip = !isFlip;
    }
    
    private void OnEnable()
    {
        GetComponent<MoveBase>().OnFlip += Flip;

        PauseSystem.PauseEvent += OnPause;
        PauseSystem.UnpauseEvent += OnUnpause;
    }
    
    private void OnDisable()
    {
        GetComponent<MoveBase>().OnFlip -= Flip;

        PauseSystem.PauseEvent -= OnPause;
        PauseSystem.UnpauseEvent -= OnUnpause;
    }
}

using System;
using UnityEngine;


[RequireComponent(typeof(PlayerMove))]
public class PlayerInput : MonoBehaviour
{
    public static float Horizontal;
    public static float Vertical;
    public static PlayerInput current;
   
    public static Action<float> OnPlayerMoveHorizontal;
    public static Action<float> OnPlayerMoveDown;
    public static Action OnPlayerJump;
    public static Action<Vector3> OnPlayerAttack;
    public static Action<Vector3> OnPlayerFlip;
    private static bool IsInputBlock = false;
    private bool isFlip = false;
    private Rigidbody2D _rigidbody2D => gameObject.GetComponent<Rigidbody2D>();
    
    private Animator Animator => gameObject.GetComponent<Animator>();
    private static float _defaultTimeScale = 1;
    private static float _pauseTimeScale = 0;


    private void Awake() //Maybe this not need??
    {
        current = this;
    }

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
        Animator?.SetFloat("yVelocity", _rigidbody2D.velocity.y);
        
        if (isFlip)
            Animator?.SetFloat("rawSpeed", -Horizontal);
        else
            Animator?.SetFloat("rawSpeed", Horizontal);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsInputBlock || PauseState.Instance.pauseMenu.activeSelf)
            {
                PauseState.Instance.TogglePauseMenu();
                PauseSwitch();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Health>().Die();
        }

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

    public static void PauseSwitch()
    {
        if (IsInputBlock)
            Time.timeScale = _defaultTimeScale;
        else
            Time.timeScale = _pauseTimeScale;
        IsInputBlock = !IsInputBlock;
    }

    public static void Pause()
    {
        IsInputBlock = true;
        Time.timeScale = _pauseTimeScale;
    }

    public static void UnPause()
    {
        IsInputBlock = false;
        Time.timeScale = _defaultTimeScale;
    }

    private void Flip()
    {
        isFlip = !isFlip;
    }
    
    private void OnEnable()
    {
        GetComponent<MoveBase>().OnFlip += Flip;
    }
    
    private void OnDisable()
    {
        GetComponent<MoveBase>().OnFlip -= Flip;
    }
}

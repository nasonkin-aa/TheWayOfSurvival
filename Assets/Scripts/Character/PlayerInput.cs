using System;
using UnityEngine;


[RequireComponent(typeof(PlayerMove))]
public class PlayerInput : MonoBehaviour
{
    public static float Horizontal;
    public static float Vertical;
    public static PlayerInput current;
   
    public static Action<float> OnPlayerMoveHorizontal;
    public static Action OnPlayerJump;
    public static Action<Vector3> OnPlayerAttack;
    public static Action<Vector3> OnPlayerFlip;
    public bool IsInputBlock = false;
    private Animator Animator => gameObject.GetComponent<Animator>();
    private float _defaultTimeScale = 1;
    private float _pauseTimeScale = 0;


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
        Animator?.SetFloat("Speed", MathF.Abs(Horizontal));
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseSwitch();

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

    public void PauseSwitch()
    {
        IsInputBlock = !IsInputBlock;
        if (Time.timeScale == _pauseTimeScale)
            Time.timeScale = _defaultTimeScale;
        else
            Time.timeScale = _pauseTimeScale;
    }
}

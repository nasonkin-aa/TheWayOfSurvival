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


    private void Awake() //Maybe this not need??
    {
        current = this;
    }

    public void FixedUpdate()
    {
        if (IsInputBlock)
            return;

        Horizontal = Input.GetAxis("Horizontal");
        OnPlayerMoveHorizontal(Horizontal);
        gameObject.GetComponent<Animator>().SetFloat("Speed", MathF.Abs(Horizontal));
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseSwitch();

        if (IsInputBlock)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            OnPlayerAttack(Input.mousePosition);
        }
      
        if (Input.GetButtonDown("Jump"))
            OnPlayerJump();

        OnPlayerFlip(Input.mousePosition);
    }

    public void PauseSwitch()
    {
        IsInputBlock = !IsInputBlock;
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }
}

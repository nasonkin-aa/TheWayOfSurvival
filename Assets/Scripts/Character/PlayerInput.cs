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

   private void Awake() //Maybe this not need
   {
      current = this;
   }

   public void FixedUpdate()
   {
      Horizontal = Input.GetAxis("Horizontal");
      OnPlayerMoveHorizontal(Horizontal);
   }

   public void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
         OnPlayerAttack(Input.mousePosition);
      }
      
      if (Input.GetButtonDown("Jump"))
         OnPlayerJump();
   }
}

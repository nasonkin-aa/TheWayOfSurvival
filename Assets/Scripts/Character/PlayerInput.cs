using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

   public static float Horizontal;
   public static float Vertical;
   public static Action<float> OnPlayerMoveHorizontal;
   public static Action OnPlayerJump;
   public static PlayerInput current;

   private void Awake()
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
      if (Input.GetButtonDown("Jump"))
         OnPlayerJump();
   }
}

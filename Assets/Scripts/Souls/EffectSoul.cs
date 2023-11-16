using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectSoul : MonoBehaviour
{
    static float magneticRadius = 2.5f;
    static float magneticForce = 0.5f;
    
    private void Update()
    {
        ApplyMagneticForce(); //Function for magnetic soul
    }

    private void ApplyMagneticForce()
    {
        var player = Player.GetPlayer.GameObject();
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < magneticRadius)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

            transform.position += directionToPlayer * (magneticForce * Time.deltaTime);
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
}

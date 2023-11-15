using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectSoul : MonoBehaviour
{
    private const float Amplitude = 0.15f;
    private const float Speed = 1.5f;
    static float magneticRadius = 2.5f;
    static float magneticForce = 0.5f;

    private Vector3 _initialPosition;
    private float _startTime;
    
    private void Start()
    {
        _initialPosition = transform.position;
        _startTime = Time.time;
    }

    private void Update()
    {
        float newY = _initialPosition.y + Amplitude * Mathf.Sin(Speed * (Time.time - _startTime));
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

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
        }
    }
}

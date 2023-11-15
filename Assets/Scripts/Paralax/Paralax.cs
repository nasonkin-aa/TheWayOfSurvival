using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private Transform followingTarget;
    [SerializeField, Range(0f, 1f)] private float parallaxStrength;
    [SerializeField] private bool disableVerticalParallax;
    [SerializeField] private bool invertParallax;
    private Vector3 _targetPreviousPosition;

    void Start()
    {
        if (Camera.main != null) 
            followingTarget = Camera.main.transform;
        else
            Debug.LogError("Camera not detected");
        _targetPreviousPosition = followingTarget.position;
    }

    void Update()
    {
        var delta = followingTarget.position - _targetPreviousPosition;

        if (disableVerticalParallax)
            delta.y = 0;
        _targetPreviousPosition = followingTarget.position;
        if (!invertParallax)
            transform.position += delta * parallaxStrength;
        else
            transform.position -= delta * parallaxStrength;
    }
}

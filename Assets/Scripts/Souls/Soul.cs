using System;
using System.Collections;
using AlexTools;
using AlexTools.Flyweight;
using Souls;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Soul : MonoFlyweight<Soul, SoulSetting>
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private new Light2D light;
    [SerializeField] private new Rigidbody2D rigidbody;
    
    private static readonly int GlowColor = Shader.PropertyToID("_GlowColor");
    
    const float MagneticRadius = 2.5f;
    const float MagneticForce = 0.5f;
    
    private Vector3 PlayerPosition => Player.Instance.transform.position;
    
    private int _points;

    public int Points
    {
        get => _points;
        set
        {
            _points = value.AtLeast(0);
            ChangeColor();
        }
    }

    private Coroutine _coroutine;

    public override void Initialize(SoulSetting settings)
    {
        base.Initialize(settings);
        
        gameObject.AssignComponentIfUnityNull(ref spriteRenderer);
        gameObject.AssignComponentIfUnityNull(ref trailRenderer);
        gameObject.AssignComponentIfUnityNull(ref light);
        gameObject.AssignComponentIfUnityNull(ref rigidbody);
    }

    public override void OnGet() => _coroutine = StartCoroutine(DespawnRoutine());

    public override void OnRelease()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        trailRenderer.Clear();
    }

    private void Update() => ApplyMagneticForce();

    private void ApplyMagneticForce()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerPosition);
        
        if (distanceToPlayer < MagneticRadius)
        {
            Vector3 directionToPlayer = (PlayerPosition - transform.position).normalized;
            transform.position += directionToPlayer * (MagneticForce * Time.deltaTime);
            rigidbody.gravityScale = 0f;
        }
        else
        {
            rigidbody.gravityScale = 0.1f;
        }
    }

    private void ChangeColor()
    {
        var newColor = Settings.GetColor(Points);
        
        spriteRenderer.color = newColor;
        spriteRenderer.material.SetColor(GlowColor, newColor);
        trailRenderer.startColor = newColor;
        light.color = newColor;
    }

    private IEnumerator DespawnRoutine()
    {
        yield return Waiters.GetWaitForSeconds(Settings.DespawnTime);
        ReleaseSelf(); 
    }
}

using UnityEngine;
using UnityEngine.UI;

public class TotemHealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image image;
    
    [SerializeField] SpriteRenderer eyeExpSpriteRenderer;
    
    private void Awake()
    {
        gameObject.AssignComponentInChildrenIfUnityNull(ref health);
        gameObject.AssignComponentIfUnityNull(ref image);
    }

    private void OnEnable()
    {
        health.ChangeEvent += OnHealthChange;
    }

    private void OnDisable()
    {
        //health.ChangeEvent += OnHealthChange;
    }

    private void OnHealthChange(int value)
    {
        var fillAmount = health.Percentage;
        image.fillAmount = fillAmount;
        
        var color = eyeExpSpriteRenderer.color;
        color.a = 1 - fillAmount;
        eyeExpSpriteRenderer.color = color;
    }
}

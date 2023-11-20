using UnityEngine;
using UnityEngine.UI;

public class HpTotemBar : MonoBehaviour
{
    private HealthBase _healthBaseTotem;
    public SpriteRenderer eyeExpSpriteRenderer;
    private void Start ()
    {
        _healthBaseTotem = transform.parent.parent.parent.GetComponent<HealthBase>();
        if (_healthBaseTotem is not null)
        {
            _healthBaseTotem.OnHpChange += UpdateBar;
            GetComponent<Image>().fillAmount = _healthBaseTotem.Health;
        }
        
        if (eyeExpSpriteRenderer is null)
            Debug.LogError("Eye Sprite Totem is null in editor");
    }

    private void UpdateBar (int value)
    {
        var fillAmount = (float)(_healthBaseTotem.Health + value) / _healthBaseTotem.MaxHealth;
        GetComponent<Image>().fillAmount = fillAmount;
        var color = eyeExpSpriteRenderer.color;
        color.a = 1 - fillAmount;
        eyeExpSpriteRenderer.color = color;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HpTotemBar : MonoBehaviour
{
    private Health _healthTotem;
    public SpriteRenderer eyeExpSpriteRenderer;
    private void Start ()
    {
        _healthTotem = transform.parent.parent.parent.GetComponent<Health>();
        if (_healthTotem is not null)
        {
            _healthTotem.ChangeEvent += UpdateBar;
            GetComponent<Image>().fillAmount = _healthTotem.CurrentHealth;
        }
        
        if (eyeExpSpriteRenderer is null)
            Debug.LogError("Eye Sprite Totem is null in editor");
    }

    private void UpdateBar (int value)
    {
        var fillAmount = (float)(_healthTotem.CurrentHealth + value) / _healthTotem.MaxHealth;
        GetComponent<Image>().fillAmount = fillAmount;
        var color = eyeExpSpriteRenderer.color;
        color.a = 1 - fillAmount;
        eyeExpSpriteRenderer.color = color;
    }
}

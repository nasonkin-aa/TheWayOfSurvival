using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LvlProgressBar : MonoBehaviour
{
    private PlayerLvl _playerLvl;
    public SpriteRenderer eyeExpSpriteRenderer;
    private Light2D eyeLight => GetComponent<Light2D>();
    private void Start ()
    {
        _playerLvl = Player.Instance?.GetComponent<PlayerLvl>();
        if (_playerLvl is not null)
            _playerLvl.OnTakeExp += UpdateBar;
        GetComponent<Image>().fillAmount = 0;
        if (eyeExpSpriteRenderer is null)
            Debug.LogError("Eye Sprite Totem is null in editor");
    }

    private void UpdateBar ()
    {
        var fillAmount = (float)_playerLvl.PlayerExp / _playerLvl.ExpToLvlUp;
        GetComponent<Image>().fillAmount = fillAmount;
        eyeLight.intensity = Mathf.Lerp(0, 2, fillAmount);
        var color = eyeExpSpriteRenderer.color;
        color.a = fillAmount;
        eyeExpSpriteRenderer.color = color;
    }
}

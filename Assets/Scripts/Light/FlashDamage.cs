using System.Collections;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{
    [SerializeField] private float flashTime = 0.25f;
    
    private SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();
    private Material GetMaterial => SpriteRenderer.material;

    private void CallDamageFlash(int value)
    {
        StartCoroutine(DamageFlasher(value));
    }

    private IEnumerator DamageFlasher(float value)
    {
        Color myColor;
        if (value < 0)
            ColorUtility.TryParseHtmlString("#FF2A2A", out myColor); // Red
        else
            ColorUtility.TryParseHtmlString("#55CF7D", out myColor); // Green
        GetMaterial.SetColor("_FlashColor", myColor);

        var elapsedTime = 0f;
        while (elapsedTime < flashTime / 2)
        {
            elapsedTime += Time.deltaTime;
            float currentFlashAmount = Mathf.Lerp(0f, 1f, (elapsedTime / (flashTime / 2) ));
            SetFlashAmount(currentFlashAmount);

            yield return null;
        }
        
        while (elapsedTime < flashTime)
        {
            elapsedTime += Time.deltaTime;
            float currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime / (flashTime) ));
            SetFlashAmount(currentFlashAmount);

            yield return null;
        }
        
    }
    private void SetFlashAmount(float amount)
    {
        GetMaterial.SetFloat("_FlashAmount", amount);
    }

    private void OnEnable()
    {
        GetComponent<Health>().ChangeEvent += CallDamageFlash;
    }

    private void OnDisable()
    {
        GetComponent<Health>().ChangeEvent -= CallDamageFlash;
    }
}

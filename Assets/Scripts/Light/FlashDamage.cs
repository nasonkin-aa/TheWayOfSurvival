using System;
using System.Collections;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{
    [SerializeField] private float flashTime = 0.25f;
    
    private SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();
    private Material Material => SpriteRenderer.material;

    private void CallDamageFlash(int value)
    {
        StartCoroutine(DamageFlasher());
    }

    private IEnumerator DamageFlasher()
    {
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
        Material.SetFloat("_FlashAmount", amount);
    }

    private void OnEnable()
    {
        GetComponent<HealthBase>().OnHpChange += CallDamageFlash;
    }

    private void OnDisable()
    {
        GetComponent<HealthBase>().OnHpChange -= CallDamageFlash;
    }
}

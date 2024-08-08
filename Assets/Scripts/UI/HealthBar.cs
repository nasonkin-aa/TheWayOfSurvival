using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image image;

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
        health.ChangeEvent -= OnHealthChange;
    }

    private void OnHealthChange(int value)
    {
        var fillAmount = health.Percentage;
        image.fillAmount = fillAmount;
    }
}

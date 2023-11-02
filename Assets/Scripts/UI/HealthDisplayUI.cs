using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthDisplayUI : MonoBehaviour
{
    private TMP_Text _valueText;
    private void Awake()
    {
        _valueText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        //Health.OnHpChange += UpdateValue;
    }

    private void UpdateValue(int value)
    {
        _valueText.text = value.ToString();
    }

    private void OnDisable()
    {
        //Health.OnHpChange -= UpdateValue;
    }
}

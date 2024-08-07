using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreUI : Singleton<ScoreUI>
{
    [SerializeField] private TMP_Text tmpText;

    protected override void Awake()
    {
        base.Awake();

        gameObject.AssignComponentIfUnityNull(ref tmpText);
    }

    private void OnEnable() => OnScoreChange(GlobalScore.Score);
    private void OnScoreChange(int value) => tmpText.text = $"Счёт: {value}";
}

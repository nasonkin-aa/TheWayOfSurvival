using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : Singleton<Score>
{
    [SerializeField] private TMP_Text tmpText;

    private void Awake()
    {
        tmpText ??= GetComponent<TMP_Text>();
    }
    
    private void Start() => OnScoreChange();

    public void OnScoreChange() => tmpText.text = $"Ñ÷¸ò: {GlobalScore.Score}";
}

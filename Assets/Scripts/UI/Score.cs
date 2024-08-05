using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : Singleton<Score>
{
    [SerializeField] private TMP_Text tmpText;

    protected override void Awake()
    {
        base.Awake();
        
        gameObject.AssignComponentIfUnityNull(ref tmpText);
    }

    private void OnEnable() => GlobalScore.ChangeEvent += OnScoreChange;
    private void OnDisable() => GlobalScore.ChangeEvent -= OnScoreChange;

    private void OnScoreChange(int value) => tmpText.text = $"Ñ÷¸ò: {value}";
}

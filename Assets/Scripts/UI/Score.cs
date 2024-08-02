using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;

    public static Score Instance { get; private set; }
    
    private void Awake()
    {
        tmpText ??= GetComponent<TMP_Text>();
        Instance = this;
    }

    private void Start() => OnScoreChange();

    public void OnScoreChange() => tmpText.text = $"Ñ÷¸ò: {GlobalScore.Score}";
}

using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    private TMP_Text m_Text;

    public static Score Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetScore();
    }

    public void SetScore()
    {
        m_Text = GetComponent<TMP_Text>();
        m_Text.text = "Ñ÷¸ò: " + GlobalScore.Score;
    }
}

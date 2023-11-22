using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    
    private TMP_Text m_Text;

    public static Score Instance { get; private set; }
    private void Awake()
    {
        if (Instance is not null)
            Destroy(gameObject);

        Instance = this;
    }

    public void SetScore()
    {
        m_Text = GetComponent<TMP_Text>();
        m_Text.text = "Score: " + GlobalScore.Instance?.Score;

    }
}

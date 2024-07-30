using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public int initialMinutes = 2;
    public int initialSeconds = 30;

    private float _currentTime;
    private bool _timerActive = true;

    private TMP_Text _timerText;

    void Start()
    {
        _timerText = GetComponent<TMP_Text>();
        _currentTime = initialMinutes * 60 + initialSeconds;
        UpdateTimerText();
    }

    void Update()
    {
        if (_timerActive)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0f)
            {
                _currentTime = 0f;
                _timerActive = false;
                int points = (int)(Player.GetPlayer.GetComponent<Health>().Percentage * 1000f);
                points += (int)(Totem.GetTotem.GetComponent<Health>().Percentage * 2000f);

                GlobalScore.AddPoints(points);
                SceneManagerSelect.SelectSceneByName("GameOver");
            }
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_currentTime / 60F);
        int seconds = Mathf.FloorToInt(_currentTime - minutes * 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        _timerText.text = timeString;
    }

    void DisplayWinMessage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
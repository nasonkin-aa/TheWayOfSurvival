using Advertisement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button button;
    public IShowAd ShowAd { get; private set; }

    protected void Awake()
    {
#if UNITY_EDITOR
        ShowAd = new EmptyAd();
#else
        ShowAd = YandexAd.Create();
#endif
    }

    private void OnEnable()
    {
        button.onClick.AddListener(ShowAd.ShowFullscreenAd);
        ShowAd.FullscreenAdCloseEvent += () => SceneManager.LoadScene("Game");
    }
}

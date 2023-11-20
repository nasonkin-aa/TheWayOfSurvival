
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayUI : MonoBehaviour
{
    private PlayerHealth playerHp;
    private void Start()
    {
        playerHp = Player.GetPlayer.GetComponent<PlayerHealth>();
        if (playerHp is not null)
            playerHp.OnHpChange += UpdateBar;
        GetComponent<Image>().fillAmount = 1;
    }

    private void UpdateBar(int value)
    {
        float fillAmount = (playerHp.Health + value) / (float) playerHp.MaxHealth;
        GetComponent<Image>().fillAmount = fillAmount;
    }
}

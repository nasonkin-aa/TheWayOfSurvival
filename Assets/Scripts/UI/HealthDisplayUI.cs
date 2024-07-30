
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayUI : MonoBehaviour
{
    private Health playerHp;
    private void Start()
    {
        playerHp = Player.GetPlayer.GetComponent<Health>();
        playerHp.ChangeEvent += UpdateBar;
        GetComponent<Image>().fillAmount = 1;
    }

    private void UpdateBar(int value)
    {
        float fillAmount = (playerHp.CurrentHealth + value) / (float) playerHp.MaxHealth;
        GetComponent<Image>().fillAmount = fillAmount;
    }
}

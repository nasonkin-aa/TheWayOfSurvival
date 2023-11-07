using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LvlProgressBar : MonoBehaviour
{
    private PlayerLvl _playerLvl;
    private void Start ()
    {
        _playerLvl = Player.GetPlayer?.GetComponent<PlayerLvl>();
        if (_playerLvl is not null)
            _playerLvl.OnTakeExp += UpdateBar;
        GetComponent<Image>().fillAmount = 0;
    }

    private void UpdateBar ()
    {
        GetComponent<Image>().fillAmount = (float)_playerLvl.PlayerExp / _playerLvl.ExpToLvlUp;
    }
}

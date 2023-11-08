using UnityEngine;

public class Rage : MonoBehaviour, IWeaponModifier
{
    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        Player.GetPlayer.GetHealth().OnHpChange -= GetPowerForLosåHp;
    }
    public void PrepareModifier()
    {
        Player.GetPlayer.GetHealth().OnHpChange += GetPowerForLosåHp;
    }

    private void GetPowerForLosåHp(int healthChange)
    {
        var wepon = Weapon.GetWeapon;
        if (wepon is not null)
            wepon.WeaponDamage -= healthChange;
    }
}

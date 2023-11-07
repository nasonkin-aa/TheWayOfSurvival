using UnityEngine;

public class Rage : MonoBehaviour, IWeaponModifier
{
    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        Player.GetPlayer.GetHealth().OnHpChange -= GetPowerForLos�Hp;
    }
    public void PrepareModifier()
    {
        Player.GetPlayer.GetHealth().OnHpChange += GetPowerForLos�Hp;
    }

    private void GetPowerForLos�Hp(int health)
    {
        var wepon = Weapon.GetWeapon;
        if (wepon is not null)
            wepon.WeaponDamage -= health;
        Debug.Log(wepon.WeaponDamage);
    }
}

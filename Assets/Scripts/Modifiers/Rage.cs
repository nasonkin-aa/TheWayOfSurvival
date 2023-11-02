using UnityEngine;

public class Rage : Modifier
{
    
    public override void ActivateEffect()
    {
        base.ActivateEffect();
    }
    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        Health.OnHpChange -= GetPowerForLos�Hp;
    }
    public override void PrepareModifier()
    {
        Health.OnHpChange += GetPowerForLos�Hp;
    }

    private void GetPowerForLos�Hp(int health)
    {
        var wepon = Weapon.GetWeapon;
        if (wepon is not null)
            wepon.WeaponDamage += 100 - health;
    }
}

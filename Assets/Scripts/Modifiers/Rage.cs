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
        Health.OnHpChange -= GetPowerForLosåHp;
    }
    public override void PrepareModifier()
    {
        Health.OnHpChange += GetPowerForLosåHp;
    }

    private void GetPowerForLosåHp(int health)
    {
        var wepon = Weapon.GetWeapon;
        if (wepon is not null)
            wepon.WeaponDamage += 100 - health;
    }
}

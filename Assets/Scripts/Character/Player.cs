using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player GetPlayer { get; private set; }
    public virtual void Awake()
    {
        GetPlayer = this;
    }
    public Weapon GetWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }

    public void AddModifier(ModifierPrepare modifier)
    {
        modifier.CreateSubObject(transform);
    }
}

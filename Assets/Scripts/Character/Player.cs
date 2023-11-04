using UnityEngine;

[RequireComponent(typeof(Health))]
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

    public Health GetHealth()
    {
        return GetComponent<Health>();
    }

    public void AddModifier(ModifierPrepare modifier)
    {
        modifier?.CreateSubObject(transform);
    }

    private void OnDestroy()
    {
        GetPlayer = null;
    }
}

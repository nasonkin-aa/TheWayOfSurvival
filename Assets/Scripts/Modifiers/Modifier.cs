using UnityEngine;

public class Modifier : MonoBehaviour, IWeaponModifier
{
    [SerializeField] protected GameObject _prefab;
    public virtual void ActivateEffect()
    {
        
    }

    public virtual void PrepareModifier()
    {
        
    }
}

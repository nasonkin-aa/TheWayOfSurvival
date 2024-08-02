using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Overlaper))]
public class Campfire : MonoBehaviour
{
    public static Campfire instance;
    [SerializeField] private ContactFilter2D _contactFilter;
    private CampfireConfig _modifierInfo;
    private Overlaper _overlaper;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this;
    }
    private void Start()
    {
        _overlaper = GetComponent<Overlaper>();
    }

    IEnumerator HealReload(float time)
    {
        yield return new WaitForSeconds(time);
        var contacts = _overlaper.CircleOverlap(_modifierInfo.Radius, _contactFilter);

        if (contacts.Count != 0)
            contacts.ForEach(obj => 
                obj.GetComponent<Health>()?.Heal(_modifierInfo.HealAmount));

        StartCoroutine(HealReload(_modifierInfo.ReloadTime));
    }

    public virtual void AddModifier(ModifierPrepare modifier)
    {
        StopAllCoroutines();
        _modifierInfo = modifier.GetModifierInfo() as CampfireConfig;

        if (_modifierInfo is null)
            return;
        StartCoroutine(HealReload(_modifierInfo.ReloadTime));
    }
}

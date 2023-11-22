using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThrowingKnife : MonoBehaviour, IWeaponModifier
{  
    private GameObject _knifePrefab;
    protected static ThrowingKnifeConfig _throwingKnifeInfo;
    private bool _IsRechargeOver = true;
 
    private ContactFilter2D contactFilter2D = Projectile.PrepareFilter();
    private CircleCollider2D _circleCollider2D;
    private void Start()
    {
        _knifePrefab = Resources.Load("Weapons/Knife") as GameObject;
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<BaseEnemy>() && _IsRechargeOver)
        {
            StartCoroutine(Shoot(other));
            _IsRechargeOver = false;
        }
    }
     IEnumerator Shoot(Collider2D other)
    {
        for(int i = 0; i < _throwingKnifeInfo.GetCountKnife; i++)
        {
            yield return new WaitForSeconds(_throwingKnifeInfo.GetTimeBetwinShot); 
            List<Collider2D> targets = OverlapTargetWithHp();
            if (targets is not null)
                SpawnKnifeWhithRototion(targets[Random.Range(0,targets.Count)]);
        }
        yield return new WaitForSeconds(_throwingKnifeInfo.GetReloadTime); 
        _IsRechargeOver = true;
    }

    public void SpawnKnifeWhithRototion(Collider2D other)
    {
        Vector3 direction = other.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var obj = Instantiate(_knifePrefab, transform.position, rotation);
        SoundManager.instance.PlaySound("Knife");
        obj.GetComponent<Knife>().PrepareKnife(_throwingKnifeInfo.GetKnifeSpeed, _throwingKnifeInfo.GetKnifeDamage);
        Destroy(obj,3f);
        
    }
    private List<Collider2D> OverlapTargetWithHp()
    {
        var collider2Ds = new List<Collider2D>();
        var countOverlapCollider = _circleCollider2D.OverlapCollider(contactFilter2D, collider2Ds);
        if (countOverlapCollider > 0)
            return collider2Ds;
        return null;
    }

    void IWeaponModifier.PrepareModifier(ModifierBaseObject ThrowingKnifeInfo)
    {
        _throwingKnifeInfo = ThrowingKnifeInfo as ThrowingKnifeConfig;
        var prefab = Resources.Load(_throwingKnifeInfo.GetPrefabPath);
        var obj = Instantiate(prefab, gameObject.transform.parent) as GameObject;
        obj.GetComponent<ThrowingKnife>().SetThrowingKnifeInfo(_throwingKnifeInfo);
        Destroy(gameObject);
    }

    public void UpdateModifierInfo(ModifierBaseObject ThrowingKnifeInfo)
    {
        _throwingKnifeInfo = ThrowingKnifeInfo as ThrowingKnifeConfig;
    }

    public void SetThrowingKnifeInfo(ThrowingKnifeConfig ThrowingKnifeInfo)
    {
        _throwingKnifeInfo = ThrowingKnifeInfo;
    }
}

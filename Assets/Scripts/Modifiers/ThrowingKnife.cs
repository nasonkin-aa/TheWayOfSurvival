using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThrowingKnife : MonoBehaviour, IWeaponModifier
{  
    [SerializeField] private GameObject _knifePrefab;
    protected static ThrowingKnifeConfig _ThrowingKnifeInfo;
    private bool _RechargeOver = true;
 
    public ContactFilter2D contactFilter2D;
    private CircleCollider2D _circleCollider2D;
    private void Start()
    {
        _knifePrefab = Resources.Load("Weapons/Knife") as GameObject;
        _circleCollider2D = GetComponent<CircleCollider2D>();

        contactFilter2D.useLayerMask = true;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<BaseEnemy>() && _RechargeOver)
        {
            StartCoroutine(MyCoroutine(other));
            _RechargeOver = false;
        }
    }
     IEnumerator MyCoroutine(Collider2D other)
    {
        for(int i = 0; i < _ThrowingKnifeInfo.GetCountKnife; i++)
        {
            yield return new WaitForSeconds(_ThrowingKnifeInfo.GetTimeBetwinShot); 
            List<Collider2D> targets = OverlapTargetWithHp();
            if (targets is not null)
                SpawnKnifeWhithRototion(targets[Random.Range(0,targets.Count)]);
        }
        yield return new WaitForSeconds(_ThrowingKnifeInfo.GetReloadTime); 
        _RechargeOver = true;
    }

    public void SpawnKnifeWhithRototion(Collider2D other)
    {
        Vector3 direction = other.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var obj = Instantiate(_knifePrefab, transform.position, rotation);
        obj.GetComponent<Knife>().PrepareKnife(_ThrowingKnifeInfo.GetKnifeSpeed, _ThrowingKnifeInfo.GetKnifeDamage);
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
        _ThrowingKnifeInfo = ThrowingKnifeInfo as ThrowingKnifeConfig;
        var prefab = Resources.Load(_ThrowingKnifeInfo.GetPrefabPath);
        var obj = Instantiate(prefab, gameObject.transform.parent) as GameObject;
        obj.GetComponent<ThrowingKnife>().SetThrowingKnifeInfo(_ThrowingKnifeInfo);
        Destroy(gameObject);
    }

    public void UpdateModifierInfo(ModifierBaseObject ThrowingKnifeInfo)
    {
        _ThrowingKnifeInfo = ThrowingKnifeInfo as ThrowingKnifeConfig;
    }

    public void SetThrowingKnifeInfo(ThrowingKnifeConfig ThrowingKnifeInfo)
    {
        _ThrowingKnifeInfo = ThrowingKnifeInfo;
    }
}

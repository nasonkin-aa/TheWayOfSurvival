using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour, IAttackable
{
    
    [SerializeField] private GameObject _test;

    public WeaponTest()
    {
        _test = Instantiate(GameObject.Find("test"));
    }
    public void Attack(Vector3 direction = new Vector3(), Vector3 point = new Vector3())
    {
        var NewTest = Instantiate(_test, point, Quaternion.identity);
        NewTest.GetComponent<Rigidbody2D>().AddForce(direction * 1000);
        NewTest.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void Attack(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}

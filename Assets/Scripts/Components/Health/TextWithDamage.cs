using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthBase))]
public class TextWithDamage : MonoBehaviour
{
    private GameObject _text;
    private HealthBase _hp;
    private static Vector2 _offset = new (0.4f, 0.4f);
    private int _offsetCount = 0;
    void Start()
    {
        _hp = GetComponent<HealthBase>();
        _hp.OnHpChange += CreateText;
        _text = (GameObject)Resources.Load("FloatingDamage");
    }

    private void CreateText(int change)
    {
        float hight = GetComponent<SpriteRenderer>().bounds.size.y;
        var instantPos = new Vector2(0, hight / 1.3f) + (Vector2)transform.position + (_offset * _offsetCount);
        _offsetCount++;
        var newText = Instantiate(_text, instantPos, Quaternion.identity);
        newText.GetComponentInChildren<FloatingDamage>().SetDamage(change);
        StartCoroutine(RemoveFloatingDamageOffset());
    }

    private void OnDisable()
    {
        if (_hp.OnHpChange is not null)
            _hp.OnHpChange -= CreateText;
    }

    private IEnumerator RemoveFloatingDamageOffset()
    {
        yield return new WaitForSeconds(1);
        _offsetCount = 0;
        StopAllCoroutines();
    }
}

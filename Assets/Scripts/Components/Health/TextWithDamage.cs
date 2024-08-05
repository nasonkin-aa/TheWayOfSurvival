using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TextWithDamage : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private GameObject _text;
    private static Vector2 _offset = new (0.4f, 0.4f);
    private int _offsetCount = 0;

    private void Awake()
    {
        gameObject.AssignComponentIfUnityNull(ref health);
        gameObject.AssignComponentIfUnityNull(ref spriteRenderer);

        _text = Resources.Load<GameObject>("FloatingDamage");
    }

    private void OnEnable()
    {
        health.ChangeEvent += OnHealthChange;
    }
    
    private void OnDisable()
    {
        health.ChangeEvent -= OnHealthChange;
    }

    private void OnHealthChange(int change)
    {
        float height = spriteRenderer.bounds.size.y;
        var instantPos = new Vector2(0, height / 1.3f) + (Vector2)transform.position + (_offset * _offsetCount);
        _offsetCount++;
        var newText = Instantiate(_text, instantPos, Quaternion.identity);
        newText.GetComponentInChildren<FloatingDamage>().SetDamage(change);
        StartCoroutine(RemoveFloatingDamageOffset());
    }


    private IEnumerator RemoveFloatingDamageOffset()
    {
        yield return new WaitForSeconds(1);
        _offsetCount = 0;
        StopAllCoroutines();
    }
}

using System;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 100;
    [SerializeField]
    private int _health;
    public Action<int> OnHpChange;
    private TextMesh hpBar;

    private void Awake()
    {
        _health = maxHealth;
    }

    private void Start()
    {
        TakeDamage(0); // Reset HP UI for default value
        CreateHPBar();
        OnHpChange += ChangeHPBar;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        //Check when damage Player, send health in UI
        //if (gameObject.layer == LayerMask.NameToLayer("Player"))
        //{
        //    OnHpChange?.Invoke(_health);
        //}
        OnHpChange?.Invoke(_health);

        if (_health <= 0) 
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        var sign = Mathf.Sign(Player.GetPlayer.transform.localScale.x);
        var scale = hpBar.transform.localScale;
        hpBar.transform.localScale = new Vector2(Mathf.Abs(scale.x) * sign, scale.y);
    }
    private void CreateHPBar ()// For testing
    {
        var subObj = SubObjectsCreator.CreateSubObjectWithModifier(transform, typeof(TextMesh)); 
        hpBar = subObj.GetComponent<TextMesh>();
        float hight = GetComponent<SpriteRenderer>().bounds.size.y / transform.localScale.y;
        Debug.Log(hight);
        subObj.transform.localPosition = new Vector2(0, hight / 2 + 3);
        hpBar.text = _health.ToString() + '/' + maxHealth;
        hpBar.fontSize = 25;
        hpBar.characterSize = 0.2f;
        hpBar.anchor = TextAnchor.MiddleCenter;

        if(GetComponent<Player>() is not null)
        {
            var sign = Mathf.Sign(Player.GetPlayer.transform.localScale.x);
            var scale = hpBar.transform.localScale;
            hpBar.transform.localScale = new Vector2(scale.x * -sign, scale.y);
        }

    }

    private void ChangeHPBar(int hp)
    {
        hpBar.text = _health.ToString() + '/' + maxHealth;
    }
}

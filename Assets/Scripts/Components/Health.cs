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
    public static Action<int> OnHpChange;
    private TextMesh hpBar;

    private void Awake()
    {
        _health = maxHealth;
    }

    private void Start()
    {
        TakeDamage(0); // Reset HP UI for default value
        CreateHPBar();
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        
        //Check when damage Player, send health in UI
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnHpChange?.Invoke(_health);
        }
        
        if (_health <= 0) 
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void UpdateHp()
    {

    }
    private void CreateHPBar ()// For testing
    {
        var subObj = SubObjectsCreator.CreateSubObjectWithModifier(transform, typeof(TextMesh)); 
        hpBar = subObj.GetComponent<TextMesh>();
        subObj.transform.localPosition = new Vector2(0, 18);
        hpBar.text = _health.ToString() + '/' + maxHealth;
        hpBar.fontSize = 25;
        hpBar.characterSize = 0.2f;
        hpBar.anchor = TextAnchor.MiddleCenter;


        var sign = Mathf.Sign(Player.GetPlayer.transform.localScale.x);
        var scale = hpBar.transform.localScale;
        hpBar.transform.localScale = new Vector2(scale.x * sign, scale.y);
    }
}

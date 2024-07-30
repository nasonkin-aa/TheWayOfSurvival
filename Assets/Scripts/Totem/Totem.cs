using System;
using UnityEngine;

public class Totem : MonoBehaviour
{
    [SerializeField] private Health health;
    public Health Health => health;
    
    private PlayerLvl _playerLvl;
    public static Totem GetTotem;
    public static Transform TotemTransform { get; set; }

    public void Awake()
    {
        health ??= GetComponent<Health>();
        
        TotemTransform = transform;
        GetTotem = this;
    }

    private void Start()
    {
        _playerLvl = Player.GetPlayer.GetComponent<PlayerLvl>();
    }

    private void OnEnable()
    {
        health.DamageEvent += OnDamage;
        health.DieEvent += OnDie;
    }

    private void OnDisable()
    {
        health.DamageEvent -= OnDamage;
        health.DieEvent -= OnDie;
    }
    
    private void OnDamage(int valie)
    {
        SoundManager.instance.PlaySound("TotemDamage");
    }
    
    private void OnDie()
    {
        GlobalScore.GameFinished();
        SceneManagerSelect.SelectSceneByName("GameOver");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerLvl.GetExp(20);
    }

    public void GetExp()
    {
        _playerLvl.GetExp(20);
    }
}

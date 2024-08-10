using UnityEngine;

public class Totem : Singleton<Totem>
{
    [SerializeField] private Health health;
    public Health Health => health;
    
    private PlayerLvl _playerLvl;

    protected override void Awake()
    {
        base.Awake();
        
        gameObject.AssignComponentIfUnityNull(ref health);
    }

    private void Start()
    {
        _playerLvl = Player.Instance.GetComponent<PlayerLvl>();
    }

    private void OnEnable()
    {
        health.DamageEvent += OnDamage;
    }

    private void OnDisable()
    {
        health.DamageEvent -= OnDamage;
    }
    
    private void OnDamage(int value)
    {
        AudioManager.Instance.Play("TotemDamage");
        _playerLvl.GetExp(value);
    }
}

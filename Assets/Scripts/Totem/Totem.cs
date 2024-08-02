using UnityEngine;

public class Totem : MonoBehaviour
{
    [SerializeField] private Health health;
    public Health Health => health;
    
    private PlayerLvl _playerLvl;
    public  Transform Transform { get; set; }

    public static Totem Instance { get; private set; }
    
    public void Awake()
    {
        health ??= GetComponent<Health>();
        
        Instance = this;
    }

    private void Start()
    {
        _playerLvl = Player.Instance.GetComponent<PlayerLvl>();
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

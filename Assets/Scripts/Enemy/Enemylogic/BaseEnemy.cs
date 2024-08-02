using System;
using Enemy;
using UnityEngine;

[RequireComponent(typeof(IHaveTarget))]
[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(Health))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected BaseEnemyConfig config;
    [SerializeField] protected Health health;

    protected IHaveTarget _targetSelector;
    protected Transform _targetTransform;
    protected MoveController _moveControl;
    protected Attack _enemyAttack;
    protected string _animatorBoolForAttack = "TargetInZone";

    protected enum EnemyState
    {
        Move,
        Attack
    }

    protected EnemyState _state = EnemyState.Move;

    public static event Action<int> DeathEvent;

    private void Awake()
    {
        health ??= GetComponent<Health>();
        config ??= Resources.Load<BaseEnemyConfig>(BaseEnemyConfig.DefaultConfigPath);
    }

    protected virtual void Start()
    {
        _enemyAttack = GetComponent<Attack>();
        _enemyAttack.OnAttackReady += ReadyToAttack;
        _enemyAttack.OnAttackFinished += FinishAttack;
        
        _moveControl = GetComponent<MoveController>();
        _targetSelector = GetComponent<IHaveTarget>();
        _targetTransform = _targetSelector.GetTarget();
        _moveControl.target = _targetTransform;
    }

    private void OnEnable()
    {
        health.DamageEvent += OnDamage;
        health.DeathEvent += OnDeath;
    }

    private void OnDisable()
    {
        health.DamageEvent -= OnDamage;
        health.DeathEvent -= OnDeath;
    }

    private void OnDamage(int value)
    {
        SoundManager.instance.PlaySound("HitSound");
    }

    private void OnDeath()
    {
        DeathEvent?.Invoke(config.ScorePoints);
        PrepareSoul();
        
        // Object Pool Doesn't Exist Yet :(
        Destroy(gameObject);
    }
    
    protected void PrepareSoul()
    {
        var soul = Soul.SpawnSoul(transform.position);
        soul.SetExp(config.SoulPoints);
    }   

    protected virtual void Update()
    {
        switch (_state)
        {
            case EnemyState.Move:
                _moveControl.MoveToTarget();
                break;
            case EnemyState.Attack:
                _moveControl.Stop();
                break;
            default:
                _moveControl.MoveToTarget();
                break;
        }
    }

    protected virtual void ReadyToAttack()
    {
        _moveControl.Flip(
            -(_moveControl.GetDirectionToObject(_moveControl.target)).x,
            gameObject);
        _state = EnemyState.Attack;
        StartAttack();
    }
    
    public virtual void StartAttack()
    {
        gameObject.GetComponent<Animator>().SetBool(_animatorBoolForAttack, true);
    }
    
    public virtual void FinishAttack()
    {
        gameObject.GetComponent<Animator>().SetBool(_animatorBoolForAttack, false);
        _state = EnemyState.Move;
    }
}

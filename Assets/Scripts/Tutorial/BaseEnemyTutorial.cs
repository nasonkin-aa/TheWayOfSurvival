using System;
using Enemy;
using UnityEngine;


public class BaseEnemyTutorial : MonoBehaviour
{
    [SerializeField] protected Health health;
    [SerializeField] protected BaseEnemyConfig config;

    [SerializeField] protected MoveController moveControl;
    [SerializeField] protected Attack enemyAttack;
    [SerializeField] protected Animator animator;
    
    protected Transform targetTransform;
    protected IHaveTarget _targetSelector;
    protected string _animatorBoolForAttack = "TargetInZone";

    protected enum EnemyState
    {
        Move,
        Attack
    }

    protected EnemyState _state = EnemyState.Move;

    public static event Action<DeathInfo> DeathEvent;

    protected virtual void Awake()
    {
        gameObject.AssignIfUnityNull(ref config, () =>
            Resources.Load<BaseEnemyConfig>(BaseEnemyConfig.GetConfigPath(name)));
        gameObject.AssignIfUnityNull(ref config, () =>
            Resources.Load<BaseEnemyConfig>(BaseEnemyConfig.DefaultConfigPath));
        
        gameObject.AssignComponentIfUnityNull(ref health);
        gameObject.AssignComponentIfUnityNull(ref enemyAttack);
        gameObject.AssignComponentIfUnityNull(ref moveControl);
        gameObject.AssignComponentIfUnityNull(ref animator);

        _targetSelector = GetComponent<IHaveTarget>();
        targetTransform = _targetSelector.GetTarget();
        moveControl.target = targetTransform;
        
        health.MaxHealth = config.MaxHealth;
        enemyAttack.Damage = config.Damage;
    }

    private void OnEnable()
    {
        enemyAttack.OnAttackReady += ReadyToAttack;
        enemyAttack.OnAttackFinished += FinishAttack;
        
        health.DamageEvent += OnDamage;
        health.DeathEvent += OnDeath;
    }

    private void OnDisable()
    {
        enemyAttack.OnAttackReady -= ReadyToAttack;
        enemyAttack.OnAttackFinished -= FinishAttack;
        
        health.DamageEvent -= OnDamage;
        health.DeathEvent -= OnDeath;
    }

    private void OnDamage(int value) => AudioManager.Instance.Play("HitSound");

    private void OnDeath()
    {
        DeathEvent?.Invoke(new DeathInfo(config, transform.position));

        // Object Pool Doesn't Exist Yet :(
        Destroy(gameObject);
    }

    protected virtual void Update()
    {
        switch (_state)
        {
            case EnemyState.Move:
                moveControl.MoveToTarget();
                break;
            case EnemyState.Attack:
                moveControl.Stop();
                break;
            default:
                moveControl.MoveToTarget();
                break;
        }
    }

    protected virtual void ReadyToAttack()
    {
        moveControl.Flip(
            -(moveControl.GetDirectionToObject(moveControl.target)).x,
            gameObject);
        _state = EnemyState.Attack;
        StartAttack();
    }
    
    public virtual void StartAttack()
    {
        animator.SetBool(_animatorBoolForAttack, true);
    }
    
    public virtual void FinishAttack()
    {
        animator.SetBool(_animatorBoolForAttack, false);
        _state = EnemyState.Move;
    }
    
    public readonly struct DeathInfo
    {
        public readonly BaseEnemyConfig Config;
        public readonly Vector3 Position;

        public DeathInfo(BaseEnemyConfig config, Vector3 position)
        {
            Config = config;
            Position = position;
        }
    }
}

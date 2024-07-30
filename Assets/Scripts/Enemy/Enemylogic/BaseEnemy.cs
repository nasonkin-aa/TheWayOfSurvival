using UnityEngine;

[RequireComponent(typeof(IHaveTarget))]
[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(Health))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected Health health;
    [SerializeField] protected int exp = 50;
    
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

    private void Awake()
    {
        health ??= GetComponent<Health>();
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
        health.DieEvent += OnDie;
    }

    private void OnDisable()
    {
        health.DamageEvent -= OnDamage;
        health.DieEvent -= OnDie;
    }

    private void OnDamage(int value)
    {
        SoundManager.instance.PlaySound("HitSound");
    }

    private void OnDie()
    {
        GlobalScore.AddPoints(exp / 2);
        PrepareSoul();
        Destroy(gameObject);
    }
    
    protected void PrepareSoul()
    {
        var soul = Soul.SpawnSoul(transform.position);
        soul.SetExp(exp);
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

using UnityEngine;

[RequireComponent(typeof(IHaveTarget))]
[RequireComponent(typeof(MoveController))]

public class BaseEnemy : MonoBehaviour
{
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

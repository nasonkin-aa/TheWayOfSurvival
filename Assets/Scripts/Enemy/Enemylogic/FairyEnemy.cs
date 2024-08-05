using System.Collections;
using UnityEngine;

[RequireComponent(typeof(FairyAttack))]
[RequireComponent(typeof(FairyMoveController))]
public class FairyEnemy : BaseEnemy
{
    [SerializeField] protected float _reloadTime = 5;
    protected bool _isReadyToAttack = true;
    
    [SerializeField] protected FairyMoveController moveController;
    [SerializeField] protected FairyAttack attack;

    protected override void Awake()
    {
        base.Awake();
        
        attack ??= GetComponent<FairyAttack>();
        moveController ??= GetComponent<FairyMoveController>();
        
        _targetSelector = GetComponent<IHaveTarget>();
        attack.SetTarget(targetTransform.GetComponent<Health>());
    }

    protected IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTime);
        _isReadyToAttack = true;

        if (attack.CheckTargetToAttack(targetTransform.GetComponent<Health>()))
            ReadyToAttack();
    }
    protected override void Update()
    {
        switch (_state)
        {
            case EnemyState.Move:
                if (_isReadyToAttack)
                    moveController.MoveToTarget();
                else
                    moveController.MoveRandom();
                break;
            case EnemyState.Attack:
                moveController.Stop();
                break;
            default:
                moveController?.MoveRandom();
                break;
        }
    }
    protected override void ReadyToAttack()
    {
        if (!_isReadyToAttack)
            return;
        _state = EnemyState.Attack;
        StartAttack();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        
        _isReadyToAttack = false;
        StartCoroutine(Reload());
    }

}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(FairyAttack))]
[RequireComponent(typeof(FairyMoveController))]
public class FairyEnemy : BaseEnemy
{
    [SerializeField] protected float _reloadTime = 5;
    protected bool _isReadyToAttack = true;
    protected FairyMoveController _moveController;
    protected FairyAttack _attack;

    protected override void Start()
    {
        _attack = GetComponent<FairyAttack>();
        _attack.OnAttackReady += ReadyToAttack;
        _attack.OnAttackFinished += FinishAttack;

        _moveController = GetComponent<FairyMoveController>();
        _targetSelector = GetComponent<IHaveTarget>();
        _targetTransform = _targetSelector.GetTarget();
        _moveController.target = _targetTransform;
        _attack.SetTrget(_targetTransform.GetComponent<Health>());
    }
    protected IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTime);
        _isReadyToAttack = true;

        if (_attack.CheckTargetToAttack(_targetTransform.GetComponent<Health>()))
            ReadyToAttack();
    }
    protected override void Update()
    {

        switch (_state)
        {
            case EnemyState.Move:
                if (_isReadyToAttack)
                    _moveController.MoveToTarget();
                else
                    _moveController.MoveRandom();
                break;
            case EnemyState.Attack:
                _moveController.Stop();
                break;
            default:
                _moveController?.MoveRandom();
                break;
        }
    }

    public override void FinishAttack()
    {
        gameObject.GetComponent<Animator>().SetBool(_animatorBoolForAttack, false);
        _isReadyToAttack = false;
        StartCoroutine(Reload());
        _state = EnemyState.Move;
    }

    protected override void ReadyToAttack()
    {
        if (!_isReadyToAttack)
            return;
        _state = EnemyState.Attack;
        StartAttack();
    }
}

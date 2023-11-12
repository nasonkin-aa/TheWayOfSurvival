using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(IHaveTarget))]
[RequireComponent(typeof(MoveController))]

public class BaseEnemy : MonoBehaviour
{
    protected IHaveTarget TargetSelector;
    protected Transform TargetTransform;
    protected MoveController MoveControl;
    protected Attack EnemyAttack;
    private enum EnemyState
    {
        Move,
        Attack

    }

    private EnemyState _state;
    void Start()
    {
        EnemyAttack = GetComponent<Attack>();
        EnemyAttack.OnAttackReady += ReadyToAttack;
        EnemyAttack.OnAttackFinished += FinishAttack;
        
        MoveControl = GetComponent<MoveController>();
        TargetSelector = GetComponent<IHaveTarget>();
        TargetTransform = TargetSelector.GetTarget();
        MoveControl.target = TargetTransform;
    }

    void Update()
    {
        switch (_state)
        {
            case EnemyState.Move:
                MoveControl.MoveToTarget();
                break;
            case EnemyState.Attack:
                
                break;
            default:
                MoveControl.MoveToTarget();
                break;
        }
    }

    private void ReadyToAttack()
    {
        _state = EnemyState.Attack;
        Debug.Log(_state);
        StartAttack();
    }
    
    public void StartAttack()
    {
        gameObject.GetComponent<Animator>().SetBool("TargetInZone", true);
    }
    
    public void FinishAttack()
    {
        gameObject.GetComponent<Animator>().SetBool("TargetInZone", false);
        _state = EnemyState.Move;
    }
}

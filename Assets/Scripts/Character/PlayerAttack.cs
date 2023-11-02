using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera _mainCamera;

    private GameObject _spawnPoint;
    private Vector3 Position => transform.position;
    private IAttackable WeaponScript => GetComponentInChildren<IAttackable>();

    private void Attack( Vector3 mousePosition)
    {
        Vector3 mouseWorldPosition = СonvertMousePosition(mousePosition);
        Vector3 attackDirection = (mouseWorldPosition - Position).normalized;
        WeaponScript?.Attack(attackDirection, Position);
    }

    private void Awake()
    {
        _mainCamera = Camera.main;  
    }

    private Vector3 СonvertMousePosition(Vector3 position)
    {
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(position);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
    public void OnEnable()
    {
        PlayerInput.OnPlayerAttack += Attack;
    }
    public void OnDisable()
    {   
        PlayerInput.OnPlayerAttack -= Attack;
    }
}

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera _mainCamera;

    private GameObject _spawnPoint;
    private Vector3 _position => transform.position;
    private IAttackable _weaponScript => GetComponentInChildren<IAttackable>();

    private void Attack( Vector3 mousePosition)
    {
        Vector3 mouseWorldPosition = СonvertMousePosition(mousePosition);
        Vector3 attackDirection = (mouseWorldPosition - _position).normalized;
        _weaponScript.Attack(attackDirection, _position);
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

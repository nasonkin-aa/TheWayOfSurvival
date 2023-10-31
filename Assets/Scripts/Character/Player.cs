using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        PlayerStatic.PlayerScript = this;
    }
    public Weapon GetWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }
}

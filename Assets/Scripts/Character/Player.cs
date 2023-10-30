using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon GetWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }
}

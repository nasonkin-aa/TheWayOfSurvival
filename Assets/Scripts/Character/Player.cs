using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshPro hpText;

    public void Start()
    {
        GetComponent<Health>().OnHpChange.AddListener(TextUpdate);
    }
    public Weapon GetWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }

    public void TextUpdate(int hp)
    {
        hpText.text = "HP: " + hp;
    }

}

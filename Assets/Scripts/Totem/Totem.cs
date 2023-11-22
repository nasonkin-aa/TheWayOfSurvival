using UnityEngine;

public class Totem : MonoBehaviour
{
    private PlayerLvl _playerLvl;
    public static Totem GetTotem;
    public static Transform TotemTransform { get; set; }

    public void Awake()
    {
        TotemTransform = transform;
        GetTotem = this;
    }

    private void Start()
    {
        _playerLvl = Player.GetPlayer.GetComponent<PlayerLvl>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerLvl.GetExp(20);
    }

    public void GetExp()
    {
        _playerLvl.GetExp(20);
    }
}

using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField] private int _exp = 20;
    public static GameObject SoulPrefab;
    
    public static GameObject LoadFromAssets() => Resources.Load("Soul") as GameObject;
    public static void SpawnSoul(Vector2 position)
    {
        SoulPrefab ??= LoadFromAssets();
        Instantiate(SoulPrefab, position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<Player>())
            return;
        SoundManager.instance.PlaySound("SoulPickUp");
        collision.gameObject.GetComponent<PlayerLvl>().GetExp(_exp);
        Destroy(gameObject);
    }

}

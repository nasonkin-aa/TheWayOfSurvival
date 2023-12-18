using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Soul : MonoBehaviour
{
    [SerializeField] private int _exp = 20;
    public static GameObject SoulPrefab;
    private SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();
    private Material GetMaterial => SpriteRenderer?.material;
    private TrailRenderer TrailRenderer => GetComponent<TrailRenderer>();
    private Light2D Light => GetComponent<Light2D>();

    public static GameObject LoadFromAssets() => Resources.Load("Soul") as GameObject;
    public static Soul SpawnSoul(Vector2 position)
    {
        SoulPrefab ??= LoadFromAssets();
        var soul = Instantiate(SoulPrefab, position, Quaternion.identity);
        return soul.GetComponent<Soul>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<Player>())
            return;
        SoundManager.instance.PlaySound("SoulPickUp");
        collision.gameObject.GetComponent<PlayerLvl>().GetExp(_exp);
        GlobalScore.AddPoints(_exp);
        Destroy(gameObject);
    }

    public void SetExp(int amount)
    {
        if (amount < 20 || amount > 60)
            return;
        _exp = amount;

        if (GetMaterial is null)
            return;

        Color myColor;
        switch (_exp)
        {
            case 30:
                ColorUtility.TryParseHtmlString("#d9de3e", out myColor); // Yellow
                break;
            case 50:
                ColorUtility.TryParseHtmlString("#FF2A2A", out myColor); // Red
                break;
            default:
                ColorUtility.TryParseHtmlString("#34ebe5", out myColor); // Blue
                break;
        }
        SpriteRenderer.color = myColor;
        GetMaterial.SetColor("_GlowColor", myColor);
        TrailRenderer.startColor = myColor;
        Light.color = myColor;
    }
}

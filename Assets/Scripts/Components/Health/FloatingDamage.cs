using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class FloatingDamage : MonoBehaviour
{
    private readonly string _color = "#CC445C"; // Красный
    public int Damage { get; private set; }
    private TextMesh _textMesh;

    void Start()
    {
        _textMesh = GetComponent<TextMesh>();
        _textMesh.text = Damage.ToString("+#;-#;0");
        if (Mathf.Sign(Damage) < 0)
        {
            ColorUtility.TryParseHtmlString(_color, out Color myColor);
            _textMesh.color = myColor;
        }
    }
    
    public void OnAnimationOver()
    {
        Destroy(transform.parent.gameObject);
    }  
    
    public void SetDamage(int damage)
    {
        Damage = damage;
    }
}

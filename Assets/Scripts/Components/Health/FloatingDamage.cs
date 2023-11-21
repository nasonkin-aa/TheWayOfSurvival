using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class FloatingDamage : MonoBehaviour
{
    private readonly string _colorDamage = "#760300"; // Red color
    private readonly string _colorHeal = "#358c3d"; // Green color
    public int Damage { get; private set; }
    private TextMesh _textMesh;

    void Start()
    {
        _textMesh = GetComponent<TextMesh>();
        _textMesh.text = Damage.ToString("+#;-#;0");
        var color = Damage < 0 ? _colorDamage : _colorHeal;

        ColorUtility.TryParseHtmlString(color, out Color myColor);
        _textMesh.color = myColor;    
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

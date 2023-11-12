using UnityEngine;

[CreateAssetMenu(fileName = "Thunderbolt Config", menuName = "Modifiers/Thunderbolt" )]
public class ThunderboltConfig : ModifierBaseObject
{
    [SerializeField] private float _radius = 2;
    [SerializeField] private int _areaDamage = 20;
    private new const string _modifierName = "Thunderbolt";

    public float Radius => _radius;
    public int AreaDamage => _areaDamage;
}

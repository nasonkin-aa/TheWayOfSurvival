using UnityEngine;

public class DrawModifier : MonoBehaviour
{
    public Player player;
    public void DrawNewModifier()
    {
        var mod = new ElectricAOE();
        var newModifier = new WeaponModifier( mod, player);
        newModifier.AddModifier();
    }
}

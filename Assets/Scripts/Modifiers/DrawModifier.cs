using UnityEngine;
using System;

public class DrawModifier : MonoBehaviour
{
    public Player player;
    private Type type = typeof(ElectricAOE);
    public void DrawNewModifier()
    {
        if (!type.IsSubclassOf(typeof(Modifier)))
            return;
        var mod = new ModifierPrepare(type); 
        var newModifier = new WeaponModifier( mod, player);
        newModifier.AddModifier();
        
        
    }
}

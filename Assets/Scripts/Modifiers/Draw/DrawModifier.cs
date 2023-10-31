using UnityEngine;
using System;
using System.Collections.Generic;

public class DrawModifier : MonoBehaviour
{
    public Player player;
    private List<Type> modifiers = new();

    /// <summary>
    /// Времянка
    /// </summary>
    private System.Random rnd = new System.Random();

    private void Awake()
    {
        modifiers.Add(typeof(ElectricAOE));
        modifiers.Add(typeof(Thunderbolt));
    }
    public void DrawNewModifier()
    {
        int randModNumber = rnd.Next(0, modifiers.Count);
        Type modifireType = modifiers[randModNumber];

        if (!modifireType.IsSubclassOf(typeof(Modifier)))
            return;

        var mod = new ModifierPrepare(modifireType);
        Debug.Log(modifireType.ToString());
        ModifierAdder.AddModifier(mod, player, ModifierTarget.Weapon);
    }
}

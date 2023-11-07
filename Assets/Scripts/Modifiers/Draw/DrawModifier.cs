using UnityEngine;
using System.Collections.Generic;

public class DrawModifier : MonoBehaviour
{
    private static List<ModifierInCard> mods = new();
    private static readonly System.Random rnd = new System.Random();

    public ModifiersPool pool;
    private void Awake()
    {
        mods = pool.modifiers;
    }
    public static void DrawNewModifier()
    {
        int randModNumber = rnd.Next(0, mods.Count);
        mods[randModNumber]?.Activate();
    }
}

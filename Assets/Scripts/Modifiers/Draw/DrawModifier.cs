using UnityEngine;
using System.Collections.Generic;

public class DrawModifier : MonoBehaviour
{
    private List<ModifierInCard> mods = new();
    private readonly System.Random rnd = new System.Random();

    public ModifiersPool pool;
    private void Awake()
    {
        mods = pool.modifiers;
    }
    public void DrawNewModifier()
    {
        int randModNumber = rnd.Next(0, mods.Count);
        mods[randModNumber].Activate();

        //if (!modifireType.IsSubclassOf(typeof(Modifier)))
        //    return;

        //var mod = new ModifierPrepare(modifireType);
        //Debug.Log(modifireType.ToString());
        //ModifierAdder.AddModifier(mod, player, ModifierTarget.Weapon);
    }
}

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DrawModifier : MonoBehaviour
{
    private static List<ModifierInCard> mods = new();
    private static readonly System.Random rnd = new System.Random();

    public Canvas DrawUI;
    public ModifiersPool pool;
    private void Awake()
    {
        mods = pool.modifiers;
    }
    public void DrawNewModifier()
    {
        PrepareUI();
        PlayerInput.Pause();
    }

    private void PrepareUI ()
    {
        DrawUI.gameObject.SetActive(true);
        PrepareCards();
    }

    private void PrepareCards()
    {
        List<Button> buttons = new (DrawUI.GetComponentsInChildren<Button>());
        foreach (var button in buttons)
        {
            Destroy(button.GetComponent<ModifierInCard>());
            int randModNumber = rnd.Next(0, mods.Count);
            var newComponent = button.gameObject.AddComponent<ModifierInCard>();
            var mod = mods[randModNumber];
            button.GetComponentInChildren<TMP_Text>().text = mod.modifierName.ToString();
            newComponent.Copy(mod);
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
                {
                    DrawUI.gameObject.SetActive(false);
                    PlayerInput.UnPause();
                    newComponent.Activate();
                });
        }
    }
}

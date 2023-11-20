using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DrawModifier : MonoBehaviour
{
    private static List<ModifierBaseObject> _pool;
    private static readonly System.Random rnd = new System.Random();

    public Canvas DrawUI;

    public static Action<Sprite> OnUpgradeSelect;
    private void Awake()
    {
        _pool = new(Resources.LoadAll<ModifierBaseObject>("").Where(obj => obj.Lvl == 1));
    }
    public void DrawNewModifier()
    {
        if (_pool.Count <= 0)
            return;

        PrepareUI();
        PlayerInput.Pause();
    }

    private void PrepareUI()
    {
        DrawUI.gameObject.SetActive(true);
        PrepareCards();
    }

    private void PrepareCards()
    {
        List<Button> buttons = new(DrawUI.GetComponentsInChildren<Button>());
        foreach (var button in buttons)
        {
            Destroy(button.GetComponent<ModifierInCard>());
            int randModNumber = rnd.Next(0, _pool.Count);
            var newComponent = button.gameObject.AddComponent<ModifierInCard>();
            var mod = _pool[randModNumber];
            PrepareButton(button, mod);
            newComponent.CopyFromSO(mod);
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
                {
                    //DrawUI.gameObject.SetActive(false); // Turn on in animation script
                    //PlayerInput.UnPause();
                    OnUpgradeSelect?.Invoke(mod.Icon);
                    newComponent.Activate();
                    UpdatePool(mod);
                });
        }
    }

    private void PrepareButton(Button button, ModifierBaseObject mod)
    {
        List<TMP_Text> buttonText = new(button.GetComponentsInChildren<TMP_Text>());
        buttonText.First(obj => obj.name == "ModifierName").text = mod.Name;
        buttonText.First(obj => obj.name == "Description").text = mod.Description.ToString();
        //buttonText.First(obj => obj.name == "ModLvl").text = mod.Lvl.ToString();
        button.GetComponentInChildren<Image>().sprite = mod.Icon;

    }

    private void UpdatePool(ModifierBaseObject mod)
    {
        _pool.Remove(mod);

        var newMods = Resources.LoadAll<ModifierBaseObject>("")
            .Where(obj => mod.GetModifierType == obj.GetModifierType &&
                   obj.Lvl == mod.Lvl + 1);

        if (newMods is null || newMods.Count() != 1)
            return;

        _pool.Add(newMods.First());
    }
}

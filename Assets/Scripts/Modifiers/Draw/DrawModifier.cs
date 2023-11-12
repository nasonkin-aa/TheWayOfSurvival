using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DrawModifier : MonoBehaviour
{
    private static List<ModifierBaseObject> _mods;
    private static readonly System.Random rnd = new System.Random();

    public Canvas DrawUI;
    private void Awake()
    {
        _mods = new(Resources.LoadAll<ModifierBaseObject>("").Where(obj => obj.Lvl == 1));
    }
    public void DrawNewModifier()
    {
        //foreach (var mod in _mods)
        //{
        //    Debug.Log(mod.GetModifierType);
        //    Debug.Log(mod.GetModifierTarget);
        //    Debug.Log(mod.Lvl);
        //}
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
            int randModNumber = rnd.Next(0, _mods.Count);
            var newComponent = button.gameObject.AddComponent<ModifierInCard>();
            var mod = _mods[randModNumber];
            PrepareButton(button, mod);
            newComponent.CopyFromSO(mod);
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
                {
                    DrawUI.gameObject.SetActive(false);
                    PlayerInput.UnPause();
                    newComponent.Activate();
                });
        }
    }

    private void PrepareButton(Button button, ModifierBaseObject mod)
    {
        List<TMP_Text> buttonText = new(button.GetComponentsInChildren<TMP_Text>());
        buttonText.First(obj => obj.name == "ModifierName").text = mod.GetModifierType.ToString();
        buttonText.First(obj => obj.name == "Description").text = mod.Description.ToString();
        buttonText.First(obj => obj.name == "ModLvl").text = mod.Lvl.ToString();
    }
}

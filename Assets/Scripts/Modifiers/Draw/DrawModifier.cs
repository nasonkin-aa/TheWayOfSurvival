using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Random = UnityEngine.Random;


public class DrawModifier : MonoBehaviour
{
    [SerializeField] private GameObject AdButton;
    private static List<ModifierBaseObject> _pool;
    private static readonly System.Random rnd = new System.Random();
    private bool CanActive;
    
    public Canvas DrawUI;

    public static Action<Sprite> OnUpgradeSelect;
    
    private void Awake()
    {
        _pool = new(Resources.LoadAll<ModifierBaseObject>("").Where(obj => obj.Lvl == 1));
    }
    public void DrawNewModifier()
    {
        CanActive = true;
        //AdButton.Enable();
        if (_pool.Count <= 0)
            return;

        StartCoroutine(Delay());
        PrepareUI();
        PauseSystem.Pause(this);
    }

    public IEnumerator Delay()
    {
        Debug.Log(CanActive);
        yield return new WaitForSecondsRealtime(2f);
        if (CanActive)
            AdButton.Enable();
        
    }
    public IEnumerator DelayForDisable()
    {
        yield return new WaitForSecondsRealtime(1f);
        CanActive = false;
    }

    public void DisableButtonAd() => StartCoroutine(DelayForDisable());
        
    private void PrepareUI()
    {
        DrawUI.gameObject.Enable();
        PrepareCards();
    }

    private void PrepareCards()
    {
        if (_pool.Count == 0)
            return;
        List<Button> buttons = new(DrawUI.GetComponentsInChildren<Button>());
        foreach (var b in buttons)
        {
            b.interactable = true;
        }

        var modifiersList = RandomizeModifiers();

        for (int modNumber = 0; modNumber < modifiersList.Count; modNumber++)
            ConfigurateButton(buttons[modNumber], modifiersList[modNumber]);

        if (modifiersList.Count < 3)
            for(int buttonNumber = buttons.Count; buttonNumber > modifiersList.Count; buttonNumber--)
                buttons[buttonNumber - 1].gameObject.SetActive(false);             
    }

    private void PrepareButton(Button button, ModifierBaseObject mod)
    {
        List<TMP_Text> buttonText = new(button.GetComponentsInChildren<TMP_Text>());
        buttonText.First(obj => obj.name == "ModifierName").text = mod.Name;
        buttonText.First(obj => obj.name == "Description").text = mod.Description.ToString();
        buttonText.First(obj => obj.name == "ModLvl").text = mod.Lvl.ToString();
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

    private void ConfigurateButton(Button button, ModifierBaseObject mod)
    {
        Destroy(button.GetComponent<ModifierInCard>());
        var newComponent = button.gameObject.AddComponent<ModifierInCard>();
        PrepareButton(button, mod);
        newComponent.CopyFromSO(mod);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            DrawUI.gameObject.Disable();
            PauseSystem.Unpause(this);

            OnUpgradeSelect?.Invoke(mod.Icon);
            newComponent.Activate();
            UpdatePool(mod);
            AdButton.Disable();
        });
        AdButton.Disable();
    }

    private List<ModifierBaseObject> RandomizeModifiers()
    {
        List<ModifierBaseObject> randomList = new ();

        int poolLength = 3;
        if (_pool.Count < poolLength)
            poolLength = _pool.Count;

        for (; randomList.Count < poolLength;)
        {
            var random = _pool[Random.Range(0, _pool.Count)];
            if (!randomList.Contains(random))
                randomList.Add(random);
        }
        return randomList;
    }
}

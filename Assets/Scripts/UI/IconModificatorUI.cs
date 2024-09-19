using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconModificatorUI : MonoBehaviour
{
    public GameObject modificatorPrefab;
    private Dictionary<string, GameObject> _modifierDictionary = new Dictionary<string, GameObject>();

    private void AddIcon(Sprite sprite)
    {
        GameObject foundObject;
        if (!_modifierDictionary.TryGetValue(sprite.name, out foundObject))
        {
            CreateModifierIcon(sprite);
        }
        else
        {
            foundObject.GetComponent<ModificatorUIInformation>().IncreaseModificatorLevel();
        }
    }

    public void CreateModifierIcon(Sprite sprite)
    {
       
            GameObject modifierIcon = Instantiate(modificatorPrefab, transform);
            modifierIcon.name = sprite.name;
            _modifierDictionary.Add(sprite.name, modifierIcon);

            Image imageUI = modifierIcon.AddComponent<Image>();
            imageUI.sprite = sprite;
            imageUI.SetNativeSize();
            modifierIcon.transform.localScale = Vector3.one;
        
    }
    private void OnEnable()
    {
        DrawModifier.OnUpgradeSelect += AddIcon;
    }

    private void OnDisable()
    {
        DrawModifier.OnUpgradeSelect -= AddIcon;
    }
    
}

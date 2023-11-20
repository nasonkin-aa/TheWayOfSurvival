using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconModificatorUI : MonoBehaviour
{
    private void AddIcon(Sprite sprite)
    {
        GameObject modifierIcon = new GameObject("ModifierIcon");
        Image imageUI = modifierIcon.AddComponent<Image>();
        imageUI.sprite = sprite;
        modifierIcon.transform.SetParent(transform);
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

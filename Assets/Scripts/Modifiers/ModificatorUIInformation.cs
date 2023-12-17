using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModificatorUIInformation : MonoBehaviour
{
    public TMP_Text TextModificatorLVL { get; private set; }
    private int _currentModificatorLVL;

    private void Start()
    {
        _currentModificatorLVL = 1;
        TextModificatorLVL = GetComponentInChildren<TMP_Text>();

        UpdateModificatorLevelText();
    }

    private void UpdateModificatorLevelText()
    {
        if (TextModificatorLVL != null)
        {
            TextModificatorLVL.text = _currentModificatorLVL.ToString();
        }
    }

    public void IncreaseModificatorLevel()
    {
        _currentModificatorLVL++;
        UpdateModificatorLevelText();
    }
}

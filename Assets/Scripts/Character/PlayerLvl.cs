using System;
using UnityEngine;

public class PlayerLvl : MonoBehaviour
{    
    private static int _playerLvl = 0;
    private static float _lvlUpCoef = 1.5f;

    public int PlayerExp { get; private set; } = 0;
    public int ExpToLvlUp { get; private set; } = 100;
    public Action OnLvlUp;
    public Action OnTakeExp;
    public DrawModifier drawMod;

    public void Start()
    {
        drawMod = FindObjectOfType<DrawModifier>();
    }

    public void GetExp (int exp)
    {
        PlayerExp += exp;

        if (PlayerExp >= ExpToLvlUp)
        {
            _playerLvl++;
            OnLvlUp?.Invoke();
            PlayerExp -= ExpToLvlUp;
            ExpToLvlUp = (int)(ExpToLvlUp * _lvlUpCoef);
            drawMod.DrawNewModifier();
        }
        OnTakeExp?.Invoke();
    }
}

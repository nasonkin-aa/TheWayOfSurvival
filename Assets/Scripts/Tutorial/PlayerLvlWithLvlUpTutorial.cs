using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLvlWithLvlUpTutorial : PlayerLvlTutorial
{
    public void LvlUp()
    {
        GetExp(ExpToLvlUp - PlayerExp);
    }
}

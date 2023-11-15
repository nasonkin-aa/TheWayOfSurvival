using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector :MonoBehaviour,  IHaveTarget
{
    public Transform GetTarget()
    {
        return Player.PlayerTransform;
    }
}

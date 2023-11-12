using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemtSelector : MonoBehaviour, IHaveTarget
{
    public Transform GetTarget()
    {
        return Totem.TotemTransform;
    }
}

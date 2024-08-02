using UnityEngine;

public class TotemtSelector : MonoBehaviour, IHaveTarget
{
    public Transform GetTarget() => Totem.Instance.transform;
}

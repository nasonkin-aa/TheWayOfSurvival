using UnityEngine;

public class PlayerSelector : MonoBehaviour,  IHaveTarget
{
    public Transform GetTarget() => Player.Instance.transform;
}

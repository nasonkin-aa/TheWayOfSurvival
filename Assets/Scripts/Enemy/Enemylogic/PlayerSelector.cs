using UnityEngine;

public class PlayerSelector : MonoBehaviour,  IHaveTarget
{
    public Transform GetTarget()
    {
        return Player.Instance.transform;
    }
}

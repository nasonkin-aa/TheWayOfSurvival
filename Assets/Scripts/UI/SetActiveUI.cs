using UnityEngine;

public class SetActiveUI : MonoBehaviour
{
    public void SetActiveGameobject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        PlayerInput.OnUnpause();
    }
}

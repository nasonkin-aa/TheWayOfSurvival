using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveUI : MonoBehaviour
{
    public void SetActiveGameobject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        PlayerInput.UnPause();
    }
}

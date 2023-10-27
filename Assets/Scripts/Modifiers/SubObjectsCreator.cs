using UnityEngine;

public class SubObjectsCreator : MonoBehaviour
{
    public static GameObject CreateSubObject (Transform parent)
    {
        GameObject subObject = Instantiate(new GameObject("SubObject"), parent);
        subObject.transform.parent = parent;
        subObject.transform.position = parent.position;
        return subObject;
    }

    public static GameObject CreateSubObjectWithModifier(Transform parent, IWeaponModifier mod)
    {
        var subObject = CreateSubObject(parent);
        var newModifier = subObject.AddComponent(mod.GetType());
        return subObject;
    }
}

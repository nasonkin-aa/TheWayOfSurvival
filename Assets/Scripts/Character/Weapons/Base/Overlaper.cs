using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Overlaper : MonoBehaviour
{
    public void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }
    public List<GameObject> CircleOverlap(float radius, ContactFilter2D filter)
    {
        var collider = GetComponent<CircleCollider2D>();
        collider.radius = radius;

        List<Collider2D> colliders = new();
        collider.OverlapCollider(filter, colliders);

        List<GameObject> finalList = new();
        colliders.ForEach(collider => finalList.Add(collider.gameObject));
        return finalList;
    }
}

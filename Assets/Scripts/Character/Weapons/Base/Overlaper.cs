using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlaper : MonoBehaviour
{
    public static List<GameObject> CircleOverlap(Vector2 overlapCirclePosition, float radius, ContactFilter2D filter)
    {
        var gameObject = Instantiate(new GameObject());
        var collider = gameObject.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
        gameObject.transform.position = collider.transform.position = overlapCirclePosition;
        collider.radius = radius;
        
        List<Collider2D> colliders = new();
        collider.OverlapCollider(filter, colliders);
        Destroy(gameObject);
        
        List<GameObject> finalList = new();
        colliders.ForEach(collider => finalList.Add(collider.gameObject));
        return finalList;
    }
}

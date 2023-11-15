using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField] private int _exp = 20;
    public static GameObject SoulPrefab;
    public static void SpawnSoul(Vector2 position)
    {
        SoulPrefab ??= LoadFromAssets();
        Instantiate(SoulPrefab, position, Quaternion.identity);
    }

    public static GameObject LoadFromAssets() => Resources.Load("Soul") as GameObject;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<Player>()) 
            return;
        other.GetComponent<PlayerLvl>()?.GetExp(_exp);
        Destroy(gameObject);
    }
}

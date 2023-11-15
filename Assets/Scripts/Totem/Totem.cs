using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Totem : MonoBehaviour
{
    private Collider2D _expZone;
    private PlayerLvl _playerLvl;

    public static Transform TotemTransform { get; set; }

    public void Awake()
    {
        TotemTransform = transform;
    }

    private void Start()
    {
        _expZone = GetComponent<Collider2D>();
        _playerLvl = Player.GetPlayer.GetComponent<PlayerLvl>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerLvl.GetExp(20);
    }

    public void GetExp()
    {
        _playerLvl.GetExp(20);
    }
}

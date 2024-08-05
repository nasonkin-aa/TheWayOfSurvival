using System;
using System.Collections;
using Souls;
using UnityEngine;

public class PlayerLvl : MonoBehaviour
{
    private static int _playerLvl = 0;
    private static float _lvlUpCoef = 60;
    private static float _timeScaleForSlowExp = .1f;
    private static float _timeForSlowExp = 1;

    [SerializeField] private float _playerExp = 0;
    public float PlayerExp
    {
        get => _playerExp;
        private set
        {
            _playerExp = value;

            if (PlayerExp >= ExpToLvlUp)
                LvlupPlayer();

            OnTakeExp?.Invoke();
        }
    }
    public float ExpToLvlUp { get; private set; } = 100;
    public Action OnLvlUp;
    public Action OnTakeExp;
    public DrawModifier drawMod;

    public void Start()
    {
        drawMod = FindObjectOfType<DrawModifier>();
    }

    private void OnEnable()
    {
        SoulCollector.PickUpEvent += OnSoulPickUp;
    }

    private void OnDisable()
    {
        SoulCollector.PickUpEvent += OnSoulPickUp;
    }

    private void OnSoulPickUp(int points) => GetExp(points);

    public void GetExp(float exp)
    {
        SoulCollector.PickUpEvent += OnSoulPickUp;
    }

    private void OnDisable()
    {
        SoulCollector.PickUpEvent -= OnSoulPickUp;
    }

    private void OnSoulPickUp(int points) => GetExp(points);

    public void GetExp(float exp)
    {
        IEnumerator corutine = GetExpSlowly(exp);
        StartCoroutine(corutine);
    }

    private IEnumerator GetExpSlowly(float exp)
    {
        var countOfTicks = _timeForSlowExp / _timeScaleForSlowExp;
        var expForTick = exp / countOfTicks;
        for (int tickNumber = 0; tickNumber < countOfTicks; tickNumber++)
        {
            PlayerExp += expForTick;
            yield return new WaitForSeconds(_timeScaleForSlowExp);
        }
    }

    protected void LvlupPlayer()
    {
        _playerLvl++;
        OnLvlUp?.Invoke();
        PlayerExp -= ExpToLvlUp;
        ExpToLvlUp += _lvlUpCoef;
        drawMod.DrawNewModifier();
    }
}

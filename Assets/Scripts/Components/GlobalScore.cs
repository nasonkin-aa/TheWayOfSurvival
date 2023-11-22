using System;
using UnityEngine;

public class GlobalScore : MonoBehaviour
{
    private int _score = 0;
    public Action<int> OnScoreChange;

    public int Score 
    { 
        get { return _score; } 
        private set {
            if (value < Score || value > 100000)
                return;
            _score = value; 
        } 
    }

    public Action OnGetPoints;
    public static GlobalScore Instance { get; private set; }
    private void Awake()
    {
        // if (Instance is not null)
        //     Destroy(gameObject); 
        Instance = this;
    }
    private void OnDisable()
    {
        LightWorld.OnNightStart -= NightStart;
    }
    private void OnEnable()
    {
        LightWorld.OnNightStart += NightStart;
    }

    public void AddPoints(int amount)
    {
        Score += amount;
        OnScoreChange?.Invoke(Score);
        Debug.Log(Score);
    }

    private void NightStart() => AddPoints(200);
}

using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public event Action<int> ScoreEvent;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void StartScoreCountEvent(int score)
    {
        ScoreEvent?.Invoke(score);
    }
}

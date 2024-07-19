using System;
using UnityEngine;

public class UserBalance : MonoBehaviour
{
    public static UserBalance Instance { get; private set; }

    public Action OnScoreAdded;

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    public void AddScore(MonoBehaviour sender, int count)
    {
        if (sender.GetType() == typeof(Player))
        {
            Score += count;
            OnScoreAdded?.Invoke();
        }
    }
}

using System;
using UnityEngine;

public class GameState: MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public Action OnGameReady;
    public Action OnGameStart;
    public Action OnGamePaused;
    public Action OnGameUnpaused;
    public Action OnGameFinished;

    private void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public State CurrentState { get; private set; }
    public void GameReady()
    { 
        CurrentState = State.Ready;
        OnGameReady?.Invoke();
    }
    public void StartGame()
    {
        CurrentState = State.InGame;
        OnGameStart?.Invoke();
    }
    public void PauseGame()
    {
        CurrentState = State.Paused;
        OnGamePaused?.Invoke();
    }
    public void UnpauseGame()
    {
        CurrentState = State.InGame;
        OnGameUnpaused?.Invoke();
    }
    public void FinishGame()
    {
        CurrentState = State.Finished;
        OnGameFinished?.Invoke();
    }
}

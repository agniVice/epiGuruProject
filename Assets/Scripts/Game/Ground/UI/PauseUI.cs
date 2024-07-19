using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        Hide();
    }
    private void OnEnable()
    {
        GameState.Instance.OnGamePaused += Show;
        GameState.Instance.OnGameUnpaused += Hide;
    }
    private void OnDisable()
    {
        GameState.Instance.OnGamePaused -= Show;
        GameState.Instance.OnGameUnpaused -= Hide;
    }
    private void Show() => _panel.SetActive(true);
    private void Hide() => _panel.SetActive(false);
    public void OnUnpauseClicked() => GameState.Instance.UnpauseGame();
}

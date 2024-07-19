using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _score;
    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        Hide();
    }
    private void OnEnable()
    {
        UserBalance.Instance.OnScoreAdded += UpdateScore;

        GameState.Instance.OnGamePaused += Hide;
        GameState.Instance.OnGameFinished += Hide;
        GameState.Instance.OnGameUnpaused += Show;
        GameState.Instance.OnGameStart += Show;
    }
    private void OnDisable()
    {
        UserBalance.Instance.OnScoreAdded -= UpdateScore;

        GameState.Instance.OnGamePaused -= Hide;
        GameState.Instance.OnGameFinished -= Hide;
        GameState.Instance.OnGameUnpaused -= Show;
        GameState.Instance.OnGameStart -= Show;
    }
    private void UpdateScore() => _score.text = UserBalance.Instance.Score.ToString();
    private void Show() => _panel.SetActive(true);
    private void Hide() => _panel.SetActive(false);
    public void OnPauseClicked() => GameState.Instance.PauseGame();
    public void OnExitClicked() => SceneLoader.Instance.LoadScene("MainScene");
}

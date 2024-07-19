using TMPro;
using UnityEngine;

public class FinishUI : MonoBehaviour
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
        GameState.Instance.OnGameFinished += Show;
    }
    private void OnDisable()
    {
        GameState.Instance.OnGameFinished -= Show;
    }
    private void Show()
    {
        _score.text = UserBalance.Instance.Score.ToString();
        _panel.SetActive(true);
    }
    private void Hide() => _panel.SetActive(false);
    public void OnExitClicked() => SceneLoader.Instance.LoadScene("MainScene");
}

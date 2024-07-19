using UnityEngine;

public class ReadyUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        Hide();
    }
    private void OnEnable()
    {
        GameState.Instance.OnGameReady += Show;
        GameState.Instance.OnGameStart += Hide;
    }
    private void OnDisable()
    {
        GameState.Instance.OnGameReady += Show;
        GameState.Instance.OnGameStart += Hide;
    }
    private void Show() => _panel.SetActive(true);
    private void Hide() => _panel.SetActive(false);

    public void OnStartClicked() => GameState.Instance.StartGame();
}

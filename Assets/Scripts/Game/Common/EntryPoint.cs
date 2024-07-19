using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public static EntryPoint Instance { get; private set; }

    [SerializeField] private GameObject[] _systems;

    private void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < _systems.Length; i++)
            Instantiate(_systems[i]);

        GameState.Instance.GameReady();
    }
}

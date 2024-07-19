using UnityEngine;

public class AppSettings : MonoBehaviour
{
    public static AppSettings Instance { get; private set; }

    private void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        DontDestroyOnLoad(gameObject);
    }
}

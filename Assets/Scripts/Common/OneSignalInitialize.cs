using UnityEngine;
using OneSignalSDK;

public class OneSignalInitialize : MonoBehaviour
{
    [SerializeField] private string _appId;
    void Start()
    {
        OneSignal.Initialize(_appId);
    }
}

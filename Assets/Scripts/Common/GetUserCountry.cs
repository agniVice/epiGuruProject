using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetUserCountry : MonoBehaviour
{
    [SerializeField] private string _urlSendRequest;
    [SerializeField] private string _exampleUserCountry;

    private string _userCountry;

    private void Start()
    {
        StartCoroutine(TryGetCountry());
    }
    private IEnumerator TryGetCountry()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(_urlSendRequest))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            { 
                Debug.Log("Request Error!");
                SceneLoader.Instance.LoadScene("MainScene");
            }
            else
            {
                string jsonValue = request.downloadHandler.text;
                RequestData data = JsonUtility.FromJson<RequestData>(jsonValue);

                if (_exampleUserCountry == "")
                    _userCountry = data.country_code;
                else
                    _userCountry = _exampleUserCountry;

                if (_userCountry == "UA")
                {
                    Debug.Log("User country: " + _userCountry + ". Loading game");
                    SceneLoader.Instance.LoadScene("MainScene");
                }
                else
                {
                    Debug.Log("User country: " + _userCountry + ". Showing WebView");
                    WebView.Instance.ShowUrlFullScreen();
                }
            }
        }
    }
    private class RequestData
    {
        public string ip;
        public string country_code;
    }
}

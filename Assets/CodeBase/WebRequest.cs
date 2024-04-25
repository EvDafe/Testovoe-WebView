using Assets.CodeBase;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : IService
{
    private readonly LoadingService _loadingService;

    public event Action RequestSended;

    public WebRequest(LoadingService loadingService) => 
        _loadingService = loadingService;

    public IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);
                    OnlineData data = webRequest.downloadHandler.text.FromJson<OnlineData>();
                    _loadingService.Progress.Data = data;
                    _loadingService.Save();
                    break;
            }
            RequestSended?.Invoke();
        }
    }
    
}

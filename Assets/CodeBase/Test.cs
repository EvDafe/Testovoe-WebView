using UnityEngine;

namespace Assets.CodeBase
{
    public class Test : MonoBehaviour
    {
        private WebView _webView;
        private LoadingService _loadingService;

        private void Start() => 
            _webView = AllServices.Container.Single<WebView>();

        public void ViewGooglePage() => 
            _webView.ShowUrlFullScreen(_loadingService.Progress.Data.link);
    }
}

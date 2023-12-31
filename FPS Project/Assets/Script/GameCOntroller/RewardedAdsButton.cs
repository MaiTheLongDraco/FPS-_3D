using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAdsButton Instance;
    [SerializeField] Button _addCoinBtn;
    [SerializeField] Text _textToChange;

    [SerializeField] GameObject _adsUI;
    [SerializeField] GameObject _congratulationUI;
    /// <summary>
    /// 
    /// </summary>

    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    [SerializeField] private ShopController shopController;
    string _adUnitId = null; // This will remain null for unsupported platforms

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // Disable the button until the ad is ready to show:
    }
    private void Start()
    {
        shopController = FindObjectOfType<ShopController>();
        _addCoinBtn.onClick.AddListener(ShowAd);
    }

    // Call this public method when you want to get an ad ready to show.
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: ----" + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:

            // Enable the button for users to click:
            _addCoinBtn.interactable = true;
        }
    }
    private void CheckAddEventForBtn(Button button)
    {
        if (button.onClick != null)
            return;
        button.onClick.AddListener(ShowAd);

    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        print("Show ad ----");
        // Disable the button:
        // _addCoinBtn.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            _adsUI.SetActive(false);
            _congratulationUI.SetActive(true);
            if (shopController == null)
            {
                var coin = PlayerPrefs.GetInt("cointAmount");
                coin += 50;
                PlayerPrefs.SetInt("cointAmount", coin);
                _textToChange.text = coin.ToString();
            }
            else
            {
                shopController.AddCoint(50);
            }

            // Grant a reward.
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _addCoinBtn.onClick.RemoveAllListeners();
    }
}
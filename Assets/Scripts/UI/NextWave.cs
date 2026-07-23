using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private AdManager _adManager;

    private void OnEnable()
    {
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
        _waveSpawner.OnWaveCompleted += HandleWaveCompleted;
        _adManager.OnAdClosed += OnAdWatched;
    }

    private void OnDisable()
    {
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
        _waveSpawner.OnWaveCompleted -= HandleWaveCompleted;
        _adManager.OnAdClosed -= OnAdWatched;
    }

    public void OnAdWatched()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveButtonClick()
    {
        _waveSpawner.StartNextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }

    private void HandleWaveCompleted()
    {
        _adManager.ShowInterstitialAd();
    }
}

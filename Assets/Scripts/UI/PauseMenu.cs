using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseClick);
        _resumeButton.onClick.AddListener(OnResumeClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseClick);
        _resumeButton.onClick.RemoveListener(OnResumeClick);
    }

    private void OnPauseClick()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnResumeClick()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}

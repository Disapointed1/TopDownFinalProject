using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
   [Inject] private PlayerHealth _playerHealth;
   [SerializeField] private GameObject _gameOverScreen;
   [SerializeField] private Button _restartButton;
   [SerializeField] private Button _exitButton;

   private void OnEnable()
   {
      _playerHealth.OnPlayerDeath += ShowGameOverScreen;
      _restartButton.onClick.AddListener(RestartButtonClick);
      _exitButton.onClick.AddListener(ExitButtonClick);
   }

   private void OnDisable()
   {
      _playerHealth.OnPlayerDeath -= ShowGameOverScreen;
      _restartButton.onClick.RemoveListener(RestartButtonClick);
      _exitButton.onClick.RemoveListener(ExitButtonClick);
   }

   private void ShowGameOverScreen()
   {
      _gameOverScreen.SetActive(true);
      Time.timeScale = 0;
   }

   private void RestartButtonClick()
   {
      _gameOverScreen.SetActive(false);
      SceneManager.LoadScene(0);
      Time.timeScale = 1;
   }

   private void ExitButtonClick()
   {
      Application.Quit();
   }
}

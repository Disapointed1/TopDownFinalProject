using System.Collections;
using System;
using UnityEngine;
using Zenject;

public class WaveSpawner : MonoBehaviour
{
   [Inject] private DiContainer _container;
   [SerializeField] private Transform[] _spawnPoints = new Transform[10];
   [SerializeField] private GameObject _zombiePrefab;
   [SerializeField] private float _spawnInterval = 2f;

   private int _currentWave = 0;
   private int _aliveZombies = 0;
   private int _zombiesInWave;
   private int _spawnPointIndex;

   public event Action OnWaveCompleted;

   private IEnumerator SpawnZombieRoutine(int count)
   {
      for (int i = 0; i < count; i++)
      {
         _spawnPointIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
         _aliveZombies++;

         GameObject zombie= _container.InstantiatePrefab(_zombiePrefab, _spawnPoints[_spawnPointIndex].position, Quaternion.identity, null);
         ZombieHealth zombieHealth = zombie.GetComponent<ZombieHealth>();
         zombieHealth.OnZombieDeath += HandleZombieDeath;
         yield return new WaitForSeconds(_spawnInterval);
      }
   }

   private void Start()
   {
      StartNextWave();
   }

   public void StartNextWave()
   {
      _currentWave++;
      _zombiesInWave = 3 +  _currentWave * 2;
      StartCoroutine(SpawnZombieRoutine(_zombiesInWave));
   }

   private void HandleZombieDeath()
   {
      _aliveZombies--;
      if (_aliveZombies <= 0)
      {
         OnWaveCompleted?.Invoke();
      }
   }


}

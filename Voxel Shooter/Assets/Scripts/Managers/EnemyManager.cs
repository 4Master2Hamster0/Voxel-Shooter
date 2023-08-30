using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _intervalBetweenSpawn;

    public List<GameObject> Enemies => _enemies;

    private void Awake() {
        if(Instance == null) Instance = this;
    }

    private void Start() {
        _intervalBetweenSpawn = ReferenceManager.Instance.DifficultyDependentData.GetInterval();
        InvokeRepeating("SpawnEnemy", 2, _intervalBetweenSpawn);
    }
    
    private void SpawnEnemy() {
        GameObject enemy = Instantiate(_enemy, GetRandomSpawnPoint().position, Quaternion.identity);
        _enemies.Add(enemy);
    }

    private Transform GetRandomSpawnPoint() {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }
}

using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenSpawnInSeconds;
    private float _timeLeft;

    private void Start()
    {
        Initialize(prefabs);
        TrySpawnEnemy();
    }

    private void TrySpawnEnemy()
    {
        if (TryGetObject(out GameObject enemy))
        {
            SetEnemy(enemy);
        }

        StartCoroutine(SetTimer(timeBetweenSpawnInSeconds));
    }

    private void SetEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint.position;
    }

    private IEnumerator SetTimer(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        TrySpawnEnemy();
    }
}
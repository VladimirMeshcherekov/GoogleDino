using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenSpawnInSeconds;
    private int _timeBetweenSpawnInMillisecond;
    private float _timeLeft;

    private void Start()
    { 
        //_timeBetweenSpawnInMillisecond = (int) (_timeBetweemSpawnInSeconds * 1000);
        Initialize(prefabs);
        // TimerCallback timerCallback = new TimerCallback(TrySpawnEnemy);
        //Timer timer = new Timer(timerCallback, 0, 0, _timeBetweenSpawnInMillisecond);
    }

    private void Update()
    {
        _timeLeft += Time.deltaTime;
        if (_timeLeft >= timeBetweenSpawnInSeconds)
        {
            TrySpawnEnemy();
            _timeLeft = 0;
        }
    }

    private void TrySpawnEnemy()
    {
        if (TryGetObject(out GameObject enemy))
        {
            SetEnemy(enemy);
        }
    }

    private void SetEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint.position;
    }
}
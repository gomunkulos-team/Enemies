using UnityEngine;
using UnityEngine.Pool;

public class EnemySrawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _spawnTime = 2;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 12;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => ActionOnGet(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetEnemy), 0.5f, _spawnTime);
    }

    private void GetEnemy()
    {
        _pool.Get();
    }

    private void ActionOnGet(Enemy enemy)
    {
        Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        Vector3 randomRotation = new Vector3(0, Random.Range(0, 360), 0);


        enemy.transform.position = spawnPosition;
        enemy.transform.Rotate(randomRotation);
        enemy.gameObject.SetActive(true);
        enemy.Fell += ReleaseEnemy;
    }

    private void ReleaseEnemy(Enemy enemy)
    {
        enemy.Fell -= ReleaseEnemy;
        _pool.Release(enemy);
    }
}

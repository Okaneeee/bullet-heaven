using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnParent;
    
    [Header("Enemy")]
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private int maxEnemies = 100;
    
    [Header("Spawn")]
    [SerializeField]
    private float spawnFrequency = 4f;
    [SerializeField]
    private int enemiesPerSpawn = 5;
    
    private float _spawnTimer;
    private int _enemiesSpawned;
    
    void Update()
    {
        if (_enemiesSpawned < maxEnemies)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= spawnFrequency)
            {
                StartCoroutine(SpawnEnemy());
                _spawnTimer = 0;
            }
        }
    }
    
    private void CountEnemies()
    {
        int nbChildren = spawnParent.GetComponentsInChildren<Transform>().Length;
        _enemiesSpawned = nbChildren - 1;
    }
    
    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnFrequency);
        
        for (int i = 0; i < enemiesPerSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnParent.transform);
            enemy.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
            _enemiesSpawned++;
            yield return new WaitForSeconds(0.1f);
        }
        CountEnemies();
    }
}

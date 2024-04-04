using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs;

    [SerializeField]
    private GameObject bossPrefab;

    [SerializeField]
    private float timeBetweenWaves = 60f;
    [SerializeField]
    private float timeBetweenEnemies = 0.5f;

    private bool bossSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWavesRoutine());
    }

    private IEnumerator SpawnWavesRoutine()
    {
        yield return new WaitForSeconds(0.5f); // Initial delay

        // Wave 1
        yield return StartCoroutine(SpawnEnemies(15, new List<int> { 0, 1 }));
        yield return new WaitForSeconds(timeBetweenWaves);

        // Wave 2
        yield return StartCoroutine(SpawnEnemies(40, new List<int> { 0, 1, 2 }));
        yield return new WaitForSeconds(timeBetweenWaves);

        // Wave 3
        yield return StartCoroutine(SpawnEnemies(60, new List<int> { 0, 1, 2, 3 }));
        yield return new WaitForSeconds(timeBetweenWaves);

        // Wave 4
        yield return StartCoroutine(SpawnEnemies(60, new List<int> { 0, 1, 2, 3, 4 }));
        yield return new WaitForSeconds(timeBetweenWaves);

        // Wave 5
        yield return StartCoroutine(SpawnEnemies(80, new List<int> { 0, 1, 2, 3, 4 }));
        yield return new WaitForSeconds(60f); // Wait 60 seconds before spawning boss
        SpawnBoss();
    }

    private IEnumerator SpawnEnemies(int count, List<int> indices)
    {
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, indices.Count);
            int enemyIndex = indices[index];
            GameObject enemyPrefab = enemyPrefabs[enemyIndex];
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenEnemies); // Wait between spawning each enemy
        }
    }

    private void SpawnBoss()
    {
        Instantiate(bossPrefab, transform.position, Quaternion.identity);
    }
}


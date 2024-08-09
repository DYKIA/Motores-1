using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemys : MonoBehaviour  //TP-Final Fernando Nogueira
{
    private Dictionary<GameObject, float> enemyDictionary = new Dictionary<GameObject, float>();

    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;

    public Transform[] spawnPoints;

    public float spawnInterval = 3f;

    void Start()
    {
        enemyDictionary.Add(enemy1Prefab, 0.33f);  // 33% de probabilidad
        enemyDictionary.Add(enemy2Prefab, 0.33f);  // 33% de probabilidad
        enemyDictionary.Add(enemy3Prefab, 0.33f);  // 33% de probabilidad

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemyToSpawn = GetRandomEnemyByProbability();

            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }

    GameObject GetRandomEnemyByProbability()
    {
        float totalProbability = 0f;

        foreach (float probability in enemyDictionary.Values)
        {
            totalProbability += probability;
        }

        float randomValue = Random.Range(0f, totalProbability);

        foreach (KeyValuePair<GameObject, float> enemy in enemyDictionary)
        {
            if (randomValue < enemy.Value)
            {
                return enemy.Key;
            }
            randomValue -= enemy.Value;
        }

        return null;
    }
}

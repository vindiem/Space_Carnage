using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Transform[] spawnPoints; // Точки спавна врагов
    public float spawnInterval = 4.0f; // Интервал между спавнами
    private bool spawningEnabled = true; // Включение/выключение спавна

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (spawningEnabled)
        {
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Vector2 spawnPosition = spawnPoints[randomSpawnIndex].position;

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ToggleSpawning(bool enable)
    {
        spawningEnabled = enable;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject healthPackPrefab; // Префаб аптечки
    public int maxEnemy = 5; // Максимальное количество аптечек
    public float timeSpawn = 0.1f; // Время между спавнами
    private float timer; // Счетчик времени

    public List<Transform> spawnPoints; // Список точек спавна

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime; // Уменьшаем таймер
        if (timer <= 0)
        {
            timer = timeSpawn; // Сбрасываем таймер
            SpawnHealth(); // Вызываем метод спавна 
        }
    }

    private void SpawnHealth()
    {
        // Проверяем, не превышает ли текущее количество аптечек максимальное
        if (transform.childCount < maxEnemy)
        {
            // Выбираем случайную точку из списка точек спавна
            Transform spawnPoint = GetRandomSpawnPoint();
            if (spawnPoint != null)
            {
                Instantiate(healthPackPrefab, spawnPoint.position, spawnPoint.rotation, transform);
            }
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // Если нет доступных точек спавна, возвращаем null
        if (spawnPoints.Count == 0)
        {
            return null;
        }

        // Выбираем случайную точку из списка
        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex];
    }


}

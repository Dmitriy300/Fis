using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject healthPackPrefab; // ������ �������
    public int maxEnemy = 5; // ������������ ���������� �������
    public float timeSpawn = 0.1f; // ����� ����� ��������
    private float timer; // ������� �������

    public List<Transform> spawnPoints; // ������ ����� ������

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime; // ��������� ������
        if (timer <= 0)
        {
            timer = timeSpawn; // ���������� ������
            SpawnHealth(); // �������� ����� ������ 
        }
    }

    private void SpawnHealth()
    {
        // ���������, �� ��������� �� ������� ���������� ������� ������������
        if (transform.childCount < maxEnemy)
        {
            // �������� ��������� ����� �� ������ ����� ������
            Transform spawnPoint = GetRandomSpawnPoint();
            if (spawnPoint != null)
            {
                Instantiate(healthPackPrefab, spawnPoint.position, spawnPoint.rotation, transform);
            }
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // ���� ��� ��������� ����� ������, ���������� null
        if (spawnPoints.Count == 0)
        {
            return null;
        }

        // �������� ��������� ����� �� ������
        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex];
    }


}

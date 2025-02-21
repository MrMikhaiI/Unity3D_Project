using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject cloudPrefab;
    public int initialClouds = 10; // Количество начальных облаков
    public float spawnZ = 50f; // Начальная позиция генерации облаков по Z
    public float spawnDistance = 20f; // Расстояние между облаками по Z
    public float minX = -10f; // Минимальная позиция по X
    public float maxX = 10f; // Максимальная позиция по X
    public float minY = 5f; // Минимальная позиция по Y
    public float maxY = 15f; // Максимальная позиция по Y

    private Transform playerTransform;

    void Start()
    {
        playerTransform = Camera.main.transform;
        GenerateInitialClouds();
    }

    void Update()
    {
        if (playerTransform.position.z > spawnZ - (spawnDistance * 2))
        {
            SpawnCloud();
            spawnZ += spawnDistance;
        }
    }

    void GenerateInitialClouds()
    {
        for (int i = 0; i < initialClouds; i++)
        {
            SpawnCloud(initialClouds == i + 1 ? true : false);
            spawnZ += spawnDistance;
        }
    }

    void SpawnCloud(bool isLast = false)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(randomX, randomY, spawnZ);
        GameObject cloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);

        // Добавляем скрипт DestroyBehindCamera к облаку
        DestroyBehindCamera destroyBehindCamera = cloud.AddComponent<DestroyBehindCamera>();

    }
}
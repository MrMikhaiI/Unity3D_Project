using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject segmentPrefab;
    public WallGenerator wallGenerator;
    public int initialSegments = 20;
    public float segmentLength = 10f;
    public float firstSegmentWithoutWalls = 1;
    private Vector3 spawnPos = Vector3.zero;

    void Start()
    {
        FirstGenerate();
    }

    void FirstGenerate()
    {
        for (int i = 0; i < initialSegments; i++)
        {
            GameObject segment = Instantiate(segmentPrefab, spawnPos, Quaternion.identity, transform);
            spawnPos.z += segmentLength;

            // Получаем компонент DestroyBehindCamera из нового сегмента
            DestroyBehindCamera destroyBehindCamera = segment.GetComponent<DestroyBehindCamera>();

            // Проверяем компонент DestroyBehindCamera на null и подписываемся на событие OnDestroyed, только если компонент существует
            if (destroyBehindCamera != null)
            {
                destroyBehindCamera.OnDestroyed.AddListener(() =>
                {
                    // Код, который выполнится при уничтожении сегмента дороги
                    AddNewSegment(); // Вызываем метод создания нового сегмента
                });
            }
            else
            {
                Debug.LogWarning("DestroyBehindCamera компонент не найден на сегменте дороги. Подписка на событие OnDestroyed не выполнена.");
            }

            // Пропускаем создание стен на первых нескольких сегментах
            if (i >= firstSegmentWithoutWalls)
            {
                wallGenerator.GenerateWallsForSegment(segment.transform);
            }
        }
    }

    public void AddNewSegment()
    {
        GameObject segment = Instantiate(segmentPrefab, spawnPos, Quaternion.identity, transform);
        spawnPos.z += segmentLength;

        // Получаем компонент DestroyBehindCamera из нового сегмента
        DestroyBehindCamera destroyBehindCamera = segment.GetComponent<DestroyBehindCamera>();

        // Проверяем компонент DestroyBehindCamera на null и подписываемся на событие OnDestroyed, только если компонент существует
        if (destroyBehindCamera != null)
        {
            destroyBehindCamera.OnDestroyed.AddListener(() =>
            {
                // Код, который выполнится при уничтожении сегмента дороги
                AddNewSegment(); // Вызываем метод создания нового сегмента
            });
        }
        else
        {
            Debug.LogWarning("DestroyBehindCamera компонент не найден на сегменте дороги. Подписка на событие OnDestroyed не выполнена.");
        }

        wallGenerator.GenerateWallsForSegment(segment.transform);
    }
}








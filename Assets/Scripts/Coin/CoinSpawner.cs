using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coinGroupPrefabs; // Массив префабов групп монет
    public Transform coinSpawnPoint; // Точка генерации монеты (CoinSpawnPoint)
    public LayerMask collisionLayer; // Слои, с которыми нужно избегать столкновений (стены, препятствия)
    public float checkRadius = 0.5f; // Радиус проверки столкновений

    void Start()
    {
        SpawnCoinGroup();
    }

    void SpawnCoinGroup()
    {
        // Проверяем, назначена ли точка спавна
        if (coinSpawnPoint == null)
        {
            Debug.LogError("CoinSpawnPoint не назначен! Убедитесь, что он находится в префабе дороги.");
            return;
        }

        // Проверяем, есть ли префабы монет
        if (coinGroupPrefabs == null || coinGroupPrefabs.Length == 0)
        {
            Debug.LogError("Не назначены префабы групп монет! Убедитесь, что массив заполнен.");
            return;
        }

        // Проверяем, есть ли столкновения в точке спавна
        Collider[] colliders = Physics.OverlapSphere(coinSpawnPoint.position, checkRadius, collisionLayer);

        if (colliders.Length > 0)
        {
            Debug.LogWarning("В точке спавна монеты обнаружено столкновение. Монета не будет сгенерирована.");
            return; // Не генерируем монету, если есть столкновение
        }

        // Выбираем случайный префаб группы монет
        int randomIndex = Random.Range(0, coinGroupPrefabs.Length);
        GameObject coinGroupPrefabToSpawn = coinGroupPrefabs[randomIndex];

        // Генерируем группу монет
        GameObject coinGroup = Instantiate(coinGroupPrefabToSpawn, coinSpawnPoint.position, coinSpawnPoint.rotation);
        coinGroup.transform.SetParent(transform); // Делаем группу монет дочерним объектом дороги (опционально)
    }

    // Для отладки - визуализация сферы проверки столкновений
    void OnDrawGizmosSelected()
    {
        if (coinSpawnPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(coinSpawnPoint.position, checkRadius);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    //public GameObject wallPrefab;
    //public Transform spawnPoint;

    //private void GenerateWall()
    //{

    //    Instantiate(wallPrefab, spawnPoint.position, Quaternion.identity, transform);
    //}
    public GameObject[] wallPrefabs; // Массив префабов стен

    [Range(0, 1)]
    public float wallSpawnChance = 0.7f;

    public int maxWallsPerSegment = 3;

    public void GenerateWallsForSegment(Transform segmentTransform)
    {
        // Находим все дочерние объекты с тегом "SpawnPoint" в текущем сегменте
        Transform[] spawnPoints = segmentTransform.GetComponentsInChildren<Transform>();
        List<Transform> availableSpawnPoints = new List<Transform>();

        // Заполняем список только теми дочерними Transform, у которых тег "SpawnPoint"
        foreach (Transform child in spawnPoints)
        {
            if (child.CompareTag("SpawnPoint") && child != segmentTransform)
            { //Убеждаемся что это не сам сегмент дороги!
                availableSpawnPoints.Add(child);
            }
        }

        int wallsSpawned = 0;

        while (availableSpawnPoints.Count > 0 && wallsSpawned < maxWallsPerSegment)
        {
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform spawnPoint = availableSpawnPoints[randomIndex];
            availableSpawnPoints.RemoveAt(randomIndex);


            if (Random.value <= wallSpawnChance)
            {
                GameObject wallPrefab = wallPrefabs[Random.Range(0, wallPrefabs.Length)];
                Instantiate(wallPrefab, spawnPoint.position, spawnPoint.rotation, segmentTransform);
                wallsSpawned++;
            }
        }
    }
}


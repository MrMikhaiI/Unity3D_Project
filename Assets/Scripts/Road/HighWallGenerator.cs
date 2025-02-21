using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighWallGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public Transform spawnPoint;

    private void GenerateWall()
    {

        Instantiate(wallPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    private void Start()
    {
        GenerateWall();
    }
}
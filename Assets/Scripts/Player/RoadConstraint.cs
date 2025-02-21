using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadCorrection : MonoBehaviour
{
    public float raycastDistance = 25.0f;
    public LayerMask groundLayer;
    public float fallThreshold = -25f;

    private bool isFalling = false;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            isFalling = false;
        }
        else
        {
            if (transform.position.y < fallThreshold)
            {
                isFalling = true;
            }
        }

        if (isFalling)
        {
            Debug.Log("Игрок упал!");
            RespawnPlayer();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * raycastDistance);
    }

    void RespawnPlayer()
    {
        // Перезагружаем текущую сцену.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
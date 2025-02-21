using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectWall : MonoBehaviour
{ 
    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, столкнулся ли игрок со стеной
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Отключаем GameObject (делаем его невидимым и неактивным)
            gameObject.SetActive(false);

            // (Опционально) Можно добавить логику для перезапуска игры,
            // возвращения игрока в начало уровня и т.п.
            Debug.Log("Игрок коснулся стены и исчез!");
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Необходимо для работы с Text

[RequireComponent(typeof(Text))]

public class Distancemeter : MonoBehaviour
{


    private Vector3 startPosition;   // Стартовая позиция, откуда будет считаться расстояние
    private Text distanceText;       // Ссылка на текстовый объект для отображения расстояния
    public Transform playerTransform; // Ссылка на Transform объекта, расстояние до которого измеряем (персонаж)

    void Awake()
    {
        // Получаем ссылку на Text компонент
        distanceText = GetComponent<Text>();

        // Проверяем, что Text компонент найден
        if (distanceText == null)
        {
            Debug.LogError("Компонент Text не найден на этом GameObject!");
            enabled = false; // Отключаем скрипт, чтобы избежать ошибок
            return;
        }

        // Сохраняем стартовую позицию (обнуляем Y координату)
        startPosition = transform.position;
        startPosition.y = 0f; // Обнуляем Y координату
    }

    void Update()
    {
        // Проверяем, что playerTransform назначен
        if (playerTransform == null)
        {
            Debug.LogWarning("Player Transform не назначен! DistanceMeter не будет работать.");
            return;
        }

        // Рассчитываем расстояние от стартовой позиции до игрока (обнуляем Y координату)
        Vector3 playerPosition = playerTransform.position;
        playerPosition.y = 0f; // Обнуляем Y координату

        float distance = Vector3.Distance(startPosition, playerPosition);

        // Округляем значение до двух знаков после запятой
        float roundedDistance = (float)Math.Round(distance, 2); // Преобразуем double в float

        // Указываем значение расстояния в тексте
        distanceText.text = "Дистанция: " + roundedDistance.ToString() + "м"; // Добавляем "m" для обозначения метров
    }
}


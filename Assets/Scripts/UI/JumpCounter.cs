using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Не забудьте добавить это!

public class JumpCounter : MonoBehaviour
{
    private int jumpCount = 0;
    public Text jumpText; // Ссылка на ваш Text Legacy UI элемент. Сделайте это *public*, чтобы можно было перетащить объект из редактора.

    void Start()
    {
        // Убедимся, что поле jumpText заполнено. Это поможет избежать ошибок.
        if (jumpText == null)
        {
            Debug.LogError("JumpCounter: Поле jumpText не заполнено! Пожалуйста, перетащите объект Text Legacy UI в это поле в инспекторе.");
            enabled = false; // Отключаем скрипт, если ссылка на текст не установлена.
        }
        UpdateJumpText(); // Инициализируем текст в начале игры.
    }

    // Функция для увеличения счетчика прыжков
    public void IncrementJumpCount()
    {
        jumpCount++;
        UpdateJumpText();
    }

    // Функция для обновления текста на экране
    private void UpdateJumpText()
    {
        if (jumpText != null)
        {
            jumpText.text = "Прыжки: " + jumpCount;
        }
        else
        {
            Debug.LogError("JumpCounter: jumpText все еще null! Что-то пошло не так.");
        }
    }
}
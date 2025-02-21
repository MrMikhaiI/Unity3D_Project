using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("OnTriggerEnter был вызван! Объект: " + gameObject.name + ", Другой объект: " + other.gameObject.name);
    //    CoinTaker taker = other.GetComponent<CoinTaker>();
    //    if (taker != null)
    //    {
    //        Debug.Log("CoinTaker найден!");
    //        Destroy(this.gameObject);
    //    }
    //    else
    //    {
    //        Debug.Log("CoinTaker не найден!");
    //    }
        
    //}

   public int coinValue = 1; // Можно настроить стоимость монеты в инспекторе.

    private void OnTriggerEnter(Collider other)
    {
        // Этот Debug.Log очень полезен для отладки. Оставьте его!
        Debug.Log("OnTriggerEnter был вызван! Объект: " + gameObject.name + ", Другой объект: " + other.gameObject.name);

        // **Важно: Уберите дублирование логики!**
        // У вас здесь две независимые проверки.  Нужно решить, какую из них использовать.
        // Сейчас скрипт пытается найти два разных компонента: CoinTaker и CoinCounter.
        // Обычно достаточно ОДНОЙ проверки.  Я рекомендую использовать CoinCounter,
        // потому что он отвечает за подсчет очков.

        // **Убираем проверку на CoinTaker (предполагается, что он больше не используется)**
        /*CoinTaker taker = other.GetComponent<CoinTaker>();
        if (taker != null)
        {
            Debug.Log("CoinTaker найден!");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("CoinTaker не найден!");
        }*/

        // Пример с Layer: Предполагается, что у вашего игрока Layer называется "Player".
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Получаем компонент CoinCounter с объекта игрока.  Важно, чтобы название компонента совпадало!
            CoinCounter collector = other.GetComponent<CoinCounter>();

            // Проверяем, что компонент CoinCounter найден.
            if (collector != null)
            {
                Debug.Log("CoinCounter найден!"); // Добавляем Debug.Log для проверки
                // Добавляем монеты.
                collector.AddCoin(coinValue); // Передаем значение монеты!

                // Уничтожаем монету.
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Монета: Игрок вошел в триггер, но на нем нет компонента CoinCounter!");
            }
        }
        else
        {
            Debug.Log("Объект не находится на слое 'Player'"); //  Добавляем Debug.Log для отладки
        }
    }
}

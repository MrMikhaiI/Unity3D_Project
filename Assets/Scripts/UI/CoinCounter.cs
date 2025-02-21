using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Необходимо для работы с Text

public class CoinCounter : MonoBehaviour
{
    private int coinCount = 0;
    public Text coinText;

    void Start()
    {
        if (coinText == null)
        {
            Debug.LogError("CoinCollector: Поле coinText не заполнено!");
            enabled = false;
        }
        UpdateCoinText();
    }


    // **Изменено: Добавлен параметр 'value'**
    public void AddCoin(int value)
    {
        coinCount += value;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Монеты: " + coinCount;
        }
        else
        {
            Debug.LogError("CoinCollector: coinText все еще null!");
        }
    }
}
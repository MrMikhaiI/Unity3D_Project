using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody rb;
    private bool isJumping;
    private JumpCounter jumpCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;

        jumpCounter = GetComponent<JumpCounter>();
        if (jumpCounter == null)
        {
            Debug.LogError("PlayerMovement: Нет компонента JumpCounter!  Прикрепите JumpCounter к игроку.");
            enabled = false;
        }
    }

    void Update()
    {
        // Проверяем нажатие пробела и *отсутствие* прыжка в данный момент
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            // Переносим вызов IncrementJumpCount() сюда, когда *фактически* прыгаем
            if (jumpCounter != null)
            {
                jumpCounter.IncrementJumpCount(); // Увеличиваем счетчик только при прыжке!
            }
        }

        //**Удаляем этот блок!** Он вызывал IncrementJumpCount() каждый кадр, что неправильно.
        /*if (jumpCounter != null) // Проверяем, что ссылка на jumpCounter не null
        {
            jumpCounter.IncrementJumpCount(); // Вызываем функцию увеличения счетчика прыжков
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false; // Когда касаемся земли, говорим, что больше не в прыжке
    }
}
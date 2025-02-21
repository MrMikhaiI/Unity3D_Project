using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public GameObject player;  // Публичная переменная для хранения ссылки на игровой объект игрока
    public float rotationSpeed = 5f; // Скорость вращения камеры (настраивается в инспекторе)

    private Vector3 offset;  // Частная переменная для хранения смещения расстояния между игроком и камерой
    private Quaternion initialRotation; // Изначальный поворот камеры

    void Start()
    {
        // Вычисляем и сохраняем значение смещения, получая расстояние между положением игрока и камеры
        offset = transform.position - player.transform.position;

        // Запоминаем изначальный поворот камеры
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Устанавливаем положение преобразования камеры таким же, как у игрока, но со смещением на вычисленное смещение расстояния
        transform.position = player.transform.position + offset;

        // Заставляем камеру смотреть на игрока
        //transform.LookAt(player.transform);

        // Плавный поворот камеры
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Альтернативный вариант: Зафиксировать вращение по X и Z осям, чтобы камера не наклонялась
        //Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        //targetRotation.x = initialRotation.x; // Сохраняем изначальное вращение по X
        //targetRotation.z = initialRotation.z; // Сохраняем изначальное вращение по Z
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        //Упрощенный вариант поворота камеры
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime * 360);


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    // Скорость перемещения игрока
    public float moveSpeed = 5f;
    // Скорость поворота игрока
    public float rotateSpeed = 720f;
    // Переменная для хранения компонента Rigidbody
   

    
    private void Update()
    {
        // Получаем элементы управления по осям (WASD или стрелки)
        float moveDirection = Input.GetAxis("Vertical");
        float rotateDirection = Input.GetAxis("Horizontal");

        // Перемещаем игрока вперед и назад
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        // Поворачиваем игрока вправо и влево
        transform.Rotate(Vector3.up, rotateDirection * rotateSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // Скорость перемещения игрока
    public float moveSpeed = 5f;
    // Скорость поворота игрока
    public float rotateSpeed = 720f;
    // Высота прыжка игрока
    public float jumpForce = 7f;

    // Переменная для хранения компонента Rigidbody
    private Rigidbody rb;
    // Переменная для проверки, находится ли игрок на земле
    private bool isGrounded;

    void Start()
    {
        // Получаем компонент Rigidbody у игрока
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Получаем элементы управления по осям (WASD или стрелки)
        float moveDirection = Input.GetAxis("Vertical");
        float rotateDirection = Input.GetAxis("Horizontal");

        // Перемещаем игрока вперед и назад
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        // Поворачиваем игрока вправо и влево
        transform.Rotate(Vector3.up, rotateDirection * rotateSpeed * Time.deltaTime);

        // Проверяем, нажата ли клавиша пробела и находится ли игрок на земле
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Добавляем вертикальную силу для прыжка
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, находится ли игрок на земле, включая столкновение с объектами, отмеченными как "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Проверяем, оторвался ли игрок от земли
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public float moveSpeed = 5f;           // Скорость движения
    public float rotateSpeed = 72f;       // Скорость поворота
    private Rigidbody _rigitbody;                  // Компонент Rigidbody
    private bool _isGrounded;               // Флаг, находится ли игрок на земле

    void Start()
    {
        _rigitbody = GetComponent<Rigidbody>();    // Получаем компонент Rigidbody
    }

    void Update()
    {
        // Получаем ввод для движения и поворота
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        // Перемещаем игрока
        transform.Translate(0, 0, move);

        // Поворачиваем игрока
        transform.Rotate(0, rotate, 0);

        
    }

    void OnCollisionStay(Collision collision)
    {
        // Проверяем, касается ли игрок поверхности с тегом "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Проверяем, перестал ли игрок касаться поверхности с тегом "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Обработчик сталкивания с предметами для предотвращения "застреваний"
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}

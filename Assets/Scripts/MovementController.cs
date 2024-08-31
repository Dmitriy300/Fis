using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    
    // Скорость передвижения
    public float speed = 1f;
    private void Update()
    {
        float xDirection = 0; 
        float zDirection = 0;

        //проверка нажатой клавиши и установка направления
        if (Input.GetKey(KeyCode.W))
        {
            zDirection = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            zDirection = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xDirection = -1;

        }

        if (Input.GetKey(KeyCode.D))
        { 
            xDirection = 1;
        }
        
        Vector3 direction = new Vector3(xDirection,0,zDirection) * (speed * Time.deltaTime);
        transform.Translate(direction);
    }
}

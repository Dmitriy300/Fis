using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    // �������� ����������� ������
    public float moveSpeed = 5f;
    // �������� �������� ������
    public float rotateSpeed = 720f;
    // ���������� ��� �������� ���������� Rigidbody
   

    
    private void Update()
    {
        // �������� �������� ���������� �� ���� (WASD ��� �������)
        float moveDirection = Input.GetAxis("Vertical");
        float rotateDirection = Input.GetAxis("Horizontal");

        // ���������� ������ ������ � �����
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        // ������������ ������ ������ � �����
        transform.Rotate(Vector3.up, rotateDirection * rotateSpeed * Time.deltaTime);
    }
}

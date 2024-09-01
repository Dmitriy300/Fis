using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public float moveSpeed = 5f;           // �������� ��������
    public float rotateSpeed = 72f;       // �������� ��������
    private Rigidbody _rigitbody;                  // ��������� Rigidbody
    private bool _isGrounded;               // ����, ��������� �� ����� �� �����

    void Start()
    {
        _rigitbody = GetComponent<Rigidbody>();    // �������� ��������� Rigidbody
    }

    void Update()
    {
        // �������� ���� ��� �������� � ��������
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        // ���������� ������
        transform.Translate(0, 0, move);

        // ������������ ������
        transform.Rotate(0, rotate, 0);

        
    }

    void OnCollisionStay(Collision collision)
    {
        // ���������, �������� �� ����� ����������� � ����� "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // ���������, �������� �� ����� �������� ����������� � ����� "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���������� ����������� � ���������� ��� �������������� "�����������"
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}

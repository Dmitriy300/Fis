using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // �������� ����������� ������
    public float moveSpeed = 5f;
    // �������� �������� ������
    public float rotateSpeed = 720f;
    // ������ ������ ������
    public float jumpForce = 7f;

    // ���������� ��� �������� ���������� Rigidbody
    private Rigidbody rb;
    // ���������� ��� ��������, ��������� �� ����� �� �����
    private bool isGrounded;

    void Start()
    {
        // �������� ��������� Rigidbody � ������
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �������� �������� ���������� �� ���� (WASD ��� �������)
        float moveDirection = Input.GetAxis("Vertical");
        float rotateDirection = Input.GetAxis("Horizontal");

        // ���������� ������ ������ � �����
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        // ������������ ������ ������ � �����
        transform.Rotate(Vector3.up, rotateDirection * rotateSpeed * Time.deltaTime);

        // ���������, ������ �� ������� ������� � ��������� �� ����� �� �����
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // ��������� ������������ ���� ��� ������
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���������, ��������� �� ����� �� �����, ������� ������������ � ���������, ����������� ��� "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // ���������, ��������� �� ����� �� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

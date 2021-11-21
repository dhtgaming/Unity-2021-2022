using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float playerSpeed = 5.0f;
    private bool isGrounded = false;
    public float sensitivity = 0.01f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * mouseXMove);
        Vector3 move = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z) *
            new Vector3(mH * playerSpeed, rb.velocity.y, mV * playerSpeed);
        rb.velocity = move;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }
    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
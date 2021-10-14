using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Mouvement : MonoBehaviour
{
    private float inputX, inputZ;

    public float speedH = 1.5f;
    public float speedV = 1.5f;

    public float mouseSensitivity = 100f;

    private float xRotation = 0f;

    public Transform playerBody;

    public CharacterController controller;

    public float speed = 12f;

    private Vector3 velocity;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        rotate();
        move();
    }

    private void move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
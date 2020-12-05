using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameManager game;
    private CharacterController controller;
    private Transform camera;
    private float sensitivity, speed;

    private float rotationX = 0f;

    private void Awake()
    {

        game = FindObjectOfType<GameManager>();
        controller = GetComponent<CharacterController>();
        camera = transform.GetChild(1);
        sensitivity = game.lookSensitivity;
        speed = game.playerSpeed;

    }

    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        Look();
        Move();

    }

    // Handles looking around using mouse
    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        camera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    // Handles player movement using WASD or arrows
    private void Move()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); // Unity uses xzy axis order

        Vector3 movement = transform.right * x + transform.forward * z;

        controller.Move(movement * speed * Time.deltaTime);

        // Press Esc to exit play mode
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }
}

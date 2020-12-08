// Handles the player controls

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    // Local variables
    private GameManager game;
    private CharacterController controller;
    new Transform camera;
    private Text time;
    private float sensitivity, speed;
    private float rotationX = 0f;

    // Begin by getting stuff from game manager
    private void Awake()
    {

        game = FindObjectOfType<GameManager>();
        controller = GetComponent<CharacterController>();
        camera = transform.Find("Camera");
        time = transform.Find("VHS Overlay").Find("Time").GetComponent<Text>();
        sensitivity = game.lookSensitivity;
        speed = game.playerSpeed;

    }

    // Hide mouse cursor at start
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Handle looking and movement every frame
    void Update()
    {

        HandleLooking();
        HandleMovement();
        HandleTime();

        // Press Esc to exit play mode,
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }

    // Look around using mouse
    private void HandleLooking()
    {

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        camera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }

    // Move using WASD or arrows
    private void HandleMovement()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); // Unity uses xzy axis order
        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * speed * Time.deltaTime);

    }

    private void HandleTime()
    {

        //float currentTime = Time.time + 50;
        //int hours = currentTime / 3600 + 1
        //int minutes = (int)((currentTime / 60 + 59) % 60);
        //int seconds = (int)(currentTime % 60);
        //int milliseconds = (int)((currentTime * 100) - (((int)currentTime) * 100));
        float currentTime = Time.time + 6360;
        //float currentTime = Time.time + 3590;
        int hours = (int)((currentTime / 3600) % 60);
        int minutes = (int)((currentTime / 60) % 60);
        int seconds = (int)(currentTime % 60);
        int milliseconds = (int)((currentTime * 100) - (((int)currentTime) * 100));

        string textHour = hours.ToString();
        string textMin = minutes.ToString();
        string textSec = seconds.ToString();
        string textMil = milliseconds.ToString();

        if (milliseconds < 10)
        {
            textMil = "0" + textMil;
        }
        if (hours < 10)
        {
            textHour = "0" + textHour;
        }
        if (seconds < 10)
        {
            textSec = "0" + textSec;
        }
        if (minutes < 10)
        {
            textMin = "0" + textMin;
        }

        time.text = textHour + ":" + textMin + ":" + textSec + ":" + textMil + "\n29 OCT. 1998";
    }
}

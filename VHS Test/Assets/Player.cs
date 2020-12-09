// Handles player controls and UI stuff

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // Local variables
    private GameManager game;
    private CharacterController controller;
    new Transform camera;
    private Text status;
    private Text time;
    private Text menu;
    private float sensitivity, speed;
    private float rotationX = 0f;
    private float initialTime, totalTime;
    private string score;

    // Begin by getting stuff from game manager
    private void Awake()
    {

        game = FindObjectOfType<GameManager>();
        controller = GetComponent<CharacterController>();
        camera = transform.Find("Camera");
        status = transform.Find("VHS Overlay").Find("Status").GetComponent<Text>();
        time = transform.Find("VHS Overlay").Find("Time").GetComponent<Text>();
        menu = transform.Find("VHS Overlay").Find("Menu").GetComponent<Text>();
        sensitivity = game.lookSensitivity;
        speed = game.playerSpeed;

    }

    // Hide mouse cursor at start
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        game.status = "play";
        initialTime = Time.time;
        menu.enabled = false;
    }

    // Handle looking and movement every frame, also resume/exit
    void Update()
    {

        HandleLooking();
        HandleMovement();
        HandleStatus();
        HandleScore();

        // Press P to play again
        if (game.status != "play" && Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // Press Esc to exit play mode,
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }

    // Look around using mouse
    private void HandleLooking()
    {

        if (game.status == "play")
        {

            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
            camera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

        }

    }

    // Move using WASD or arrows
    private void HandleMovement()
    {

        if (game.status == "play")
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical"); // Unity uses xzy axis order
            Vector3 movement = transform.right * x + transform.forward * z;
            controller.Move(movement * speed * Time.deltaTime);

        }

    }

    // Checks and displays game status
    private void HandleStatus()
    {
        
        if (game.status == "play")
        {
            status.text = "PLAY ▶";
            menu.enabled = false;
        }
        else if (game.status == "dead")
        {
            //status.text = "DEAD ▇\nPRESS P TO PLAY";
            status.text = "DEAD ∎∎";
            menu.enabled = true;
        }
        else
        {
            status.text = "PAUSE ∎∎";
        }

    }

    // Displays the time stuff for when alive and dead
    private void HandleScore()
    {

        if (game.status == "play")
        {

            //totalTime = Time.time + 6360;
            totalTime = Time.time - initialTime + 6360;
            int hours = (int)((totalTime / 3600) % 60);
            int minutes = (int)((totalTime / 60) % 60);
            int seconds = (int)(totalTime % 60);
            int milliseconds = (int)((totalTime * 100) - (((int)totalTime) * 100));

            string scoreHour = hours.ToString();
            string scoreMin = minutes.ToString();
            string scoreSec = seconds.ToString();
            string scoreMil = milliseconds.ToString();

            if (milliseconds < 10)
            {
                scoreMil = "0" + scoreMil;
            }
            if (hours < 10)
            {
                scoreHour = "0" + scoreHour;
            }
            if (seconds < 10)
            {
                scoreSec = "0" + scoreSec;
            }
            if (minutes < 10)
            {
                scoreMin = "0" + scoreMin;
            }

            score = scoreHour + ":" + scoreMin + ":" + scoreSec + ":" + scoreMil;
            time.text = score + "\n29 OCT. 1998";

        }

        else if (game.status == "dead")
        {
            //PlayerPrefs.SetFloat("HighScore", totalTime);
            if (totalTime > PlayerPrefs.GetFloat("HighScoreFloat"))
            {
                PlayerPrefs.SetFloat("HighScoreFloat", totalTime);
                PlayerPrefs.SetString("HighScoreString", score);
            }

            Debug.Log(totalTime);

            time.text = "YOU LASTED: " + score + "\nBEST TIME: " + PlayerPrefs.GetString("HighScoreString");
        }


        
    }
}

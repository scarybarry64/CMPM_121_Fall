// By Barry Day, 10-18-20
// This script handles the player, "Bill Ball"

using UnityEngine;
using UnityEngine.UI;

public class BillBall : MonoBehaviour
{
    public CharacterController Controller;
    public Camera CameraFirst;
    public Camera CameraThird;
    public int state = 0;
    public int camera = 1;
    public int petePowerLevel = 0;
    public Text Display;
    [Range(0.1f, 10)] public float speed;

    private void Update()
    {
        // Handle movement based off camera
        // In first person, can see Pete Powers but can only move camera
        // In third person, can move self but can't see Pete Powers
        if (camera == 1)
        {
            CameraFirst.depth = 1;

            if (Input.GetKey(KeyCode.A))
            {
                CameraFirst.transform.Rotate(0, -0.3f, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CameraFirst.transform.Rotate(0, 0.3f, 0);
            }
        }
        else
        {
            CameraFirst.depth = -1;
            Controller.SimpleMove(new Vector3(speed * Input.GetAxis("Horizontal"), 0, speed * Input.GetAxis("Vertical")));
        }

        // Switch cameras if C is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            camera *= -1;
        }

        // Win game if all 5 Pete Powers are collected
        if (petePowerLevel == 5)
        {
            state = 1;
        }

        // Handle display
        if (state == 0)
        {
            Display.text = "PETE POWER: " + petePowerLevel.ToString();
        }
        else if (state == 1) // WIN
        {
            Display.text = "Bill Ball! Yay!!!";
        }
        else if (state == -1) // LOSE
        {
            Display.text = "Bob Box . . . Ewww!";
        }
    }

    // Lose if ya hit Bob Box cuz he sucks
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "BobBox")
        {
            state = -1;
        }
    }
}

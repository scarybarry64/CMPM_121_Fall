// Moves the player on the XZ plane via WASD and arrows

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Public
    [Range(1f, 20f)] public float speed;
    [HideInInspector] public bool visionEnabled;

    // Private
    private CharacterController playerController;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        visionEnabled = false;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); // Unity uses xzy axis order

        Vector3 movement = transform.right * x + transform.forward * z;

        playerController.Move(movement * speed * Time.deltaTime);

        // Hold left click to use VHS-Vision
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("VHS VISION");
            visionEnabled = true;

        }
        else
        {
            visionEnabled = false;
        }

        // Press Esc to exit play mode
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

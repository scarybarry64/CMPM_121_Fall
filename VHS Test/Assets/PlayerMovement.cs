// Moves the player on the XZ plane via WASD and arrows

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Public
    [Range(1f, 20f)] public float speed;

    // Private
    private CharacterController playerController;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); // Unity uses xzy axis order

        Vector3 movement = transform.right * x + transform.forward * z;

        playerController.Move(movement * speed * Time.deltaTime);

        // Press Esc to exit play mode
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

// Acts as a central brain that connects the game together
// Stores the various settings for the player and enemies

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Player variables
    [Header("PLAYER SETTINGS")]

    [Tooltip("Mouse sensitivity for looking")]
    [Range(100, 1000)] public float lookSensitivity;

    [Tooltip("How fast the player moves")]
    [Range(1, 50)] public float playerSpeed;

    // Enemy variables
    [Header("ENEMY SETTINGS")]

    [Tooltip("How fast enemy 1 moves")]
    [Range(1, 200)] public float enemy1Speed;

    [Tooltip("How far enemy 1 can aggro the player")]
    [Range(0.01f, 100)] public float enemy1DetectionRadius;

    [Tooltip("How fast enemy 2 moves")]
    [Range(1, 200)] public float enemy2Speed;

    [Tooltip("No idea how to describe this")]
    [Range(0.01f, 100)] public float enemy2DetectionRadius;

    [Tooltip("How fast enemy 3 moves")]
    [Range(1, 200)] public float enemy3Speed;


    // Other stuff
    [HideInInspector] public string status;

}

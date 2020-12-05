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
    [Range(1, 500)] public float enemy1Speed;

    [Tooltip("How far enemy 1 can aggro the player")]
    [Range(10, 100)] public float enemy1DetectionRadius;

    [Tooltip("How fast enemy 2 moves")]
    [Range(1, 50)] public float enemy2Speed;

    [Tooltip("No idea how to describe this")]
    [Range(10, 100)] public float enemy2DetectionRadius;

    [Tooltip("How fast enemy 3 moves")]
    [Range(1, 50)] public float enemy3Speed;

    private void Awake()
    {
        //
    }

}

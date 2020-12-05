﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{

    // Public
    [Range(1, 50)] public float speed;
    [Range(1, 20)] public float detectionRadius;
    public PlayerMovement player;
    public Camera mainCam;

    // Private
    private Rigidbody Body;
    private MeshRenderer Mesh;
    private Vector3 Movement;

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
        Mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {

        RaycastHit hit;

        if (Physics.SphereCast(mainCam.transform.position, detectionRadius, mainCam.transform.forward, out hit, 10000))
        {
            Debug.Log("Looked at!");
            FollowPlayer();
        }
        else
        {
            Debug.Log("Not looked at!");
        }


    }

    // Faces and moves toward the player
    // Code from: https://www.youtube.com/watch?v=4Wh22ynlLyk
    private void FollowPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Body.rotation = Quaternion.Euler(0, angle, 0);
        direction.Normalize();
        Body.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
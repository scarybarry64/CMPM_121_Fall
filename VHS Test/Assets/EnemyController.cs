// "Pale Lady" - based off the Weeping Angels from Doctor Who
// Quickly moves toward the payer when not in camera view
// Honestly some scary shit

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Local variables
    private GameManager game;
    private Player player;
    private Rigidbody body;
    private Vector3 movement;
    private float speed, detectionRadius;
    private bool visible = false;

    // Initialize stuff
    private void Awake()
    {

        game = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        body = GetComponent<Rigidbody>();
        speed = game.enemy1Speed;
        detectionRadius = game.enemy1DetectionRadius;

    }

    // Every frame, track distance and determine follow behaviour
    private void Update()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (!visible && distance <= detectionRadius)
        {
            FollowPlayer();
        }

    }

    // Track visiblity
    private void OnBecameInvisible()
    {
        visible = false;
    }

    // Ditto
    private void OnBecameVisible()
    {
        visible = true;
    }

    // Player go bye-bye when Pale Lady reaches em
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            Debug.Log("get fukt");
            game.status = "dead";
        }
    }

    // Faces and moves toward the player
    // Code from: https://www.youtube.com/watch?v=4Wh22ynlLyk
    // Creepy af
    private void FollowPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        body.rotation = Quaternion.Euler(0, angle, 0);
        direction.Normalize();
        body.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}

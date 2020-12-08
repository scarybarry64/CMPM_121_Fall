using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Public
    //[Range(1, 50)] public float speed;
    //[Range(10, 100)] public float detectionRadius;
    //public PlayerMovement player;

    // Local
    private GameManager game;
    private Player player;
    private Rigidbody body;
    private Vector3 movement;
    private float speed, detectionRadius;
    private bool visible = false;

    private void Awake()
    {
        game = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        body = GetComponent<Rigidbody>();

        speed = game.enemy1Speed;
        detectionRadius = game.enemy1DetectionRadius;

    }

    // Update is called once per frame
    private void Update()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (!visible && distance <= detectionRadius)
        {
            FollowPlayer();
        }

    }

    private void OnBecameInvisible()
    {
        visible = false;
    }

    private void OnBecameVisible()
    {
        visible = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            Debug.Log("HIT!");
            
        }
    }

    // Faces and moves toward the player
    // Code from: https://www.youtube.com/watch?v=4Wh22ynlLyk
    private void FollowPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        body.rotation = Quaternion.Euler(0, angle, 0);
        direction.Normalize();
        body.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}

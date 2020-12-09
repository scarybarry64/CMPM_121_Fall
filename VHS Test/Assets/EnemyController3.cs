// UNFINISHED
// Always follows the player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController3 : MonoBehaviour
{

    // Local variables
    private GameManager game;
    private Player player;
    private Rigidbody body;
    private Vector3 movement;
    private float speed;

    private void Awake()
    {

        game = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        body = GetComponent<Rigidbody>();
        speed = game.enemy3Speed;

    }

    // Update is called once per frame
    private void Update()
    {

        FollowPlayer();


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

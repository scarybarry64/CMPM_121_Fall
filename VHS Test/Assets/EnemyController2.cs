// UNFINISHED
// Always follows the player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController2 : MonoBehaviour
{

    // Local variables
    private GameManager game;
    private Player player;
    new Transform camera;
    private Rigidbody body;
    private NavMeshAgent agent;
    private Vector3 movement;
    private float speed;

    private LayerMask mask;
    private bool inFlashlight = false;



    private void Awake()
    {

        game = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        body = GetComponent<Rigidbody>();
        //agent = GetComponent<NavMeshAgent>();
        speed = game.enemy2Speed;

        mask = LayerMask.GetMask("Obstacles");

        camera = player.transform.Find("Camera");

    }

    // Update is called once per frame
    private void Update()
    {

        //if (inFlashlight && !Physics.Linecast(transform.position, camera.transform.position, mask))
        //{
        //    Debug.Log("Success!");
        //}
        if (inFlashlight)
        {
            if (!Physics.Linecast(transform.position, player.transform.position, mask))
            {
                //Debug.Log("Success!");
                //agent.SetDestination(player.transform.position);
                //body.MovePosition(transform.position + (agent.velocity * speed * Time.deltaTime));
                //agent.velocity = new Ve
                //FollowPlayer();
                //agent.velocity = (player.transform.position - transform.position) * speed * 2f * Time.deltaTime;

                //Debug.Log("player - enemy: " + (player.transform.position - transform.position));
                //Debug.Log("speed * time: " + (speed * Time.deltaTime));
                //Debug.Log("speed: " + speed);

                //Debug.Log(agent.velocity);
                //Debug.Log(speed);
                FollowPlayer();
            }
            else
            {
                //Debug.Log("Invalid!");
                //agent.velocity = Vector3.zero;
                //Debug.Log(agent.velocity);

                //agent.SetDestination(transform.position);

            }
        }

    }

    // Player go bye-bye when Pale Lady reaches em
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Flashlight"))
        {
            //Debug.Log("YO");
            inFlashlight = true;
        }
        if (collider.CompareTag("Player"))
        {
            game.status = "dead";
        }

    }

    private void OnTriggerExit(Collider collider)
    {

        if (collider.CompareTag("Flashlight"))
        {
            //Debug.Log("YO 2");
            inFlashlight = false;
            //agent.SetDestination(transform.position);
            //agent.velocity = Vector3.zero;
            //Debug.Log(agent.velocity);

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
        //body.MovePosition(transform.position + (agent.velocity * speed * Time.deltaTime));
        //agent.SetDestination(transform.position + (direction * speed * speed * speed * Time.deltaTime)); // NEEDS ADJUST
    }

    //private void Something()
    //{
    //    Ray ray = cam.ScreenPointToRay(pos);
    //    Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    //}
}

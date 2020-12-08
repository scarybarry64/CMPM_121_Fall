using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{

    // Public
    //[Range(1, 50)] public float speed;
    //[Range(1, 20)] public float detectionRadius;
    //public PlayerMovement player;
    public Camera camera;

    // Local variables
    private GameManager game;
    private Player player;
    //private Camera camera;
    private Rigidbody body;
    private MeshRenderer mesh;
    private Vector3 movement;
    private float speed, detectionRadius;



    private float dis;

    private void Awake()
    {

        game = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        //camera = player.transform.GetChild(1).GetComponent<Camera>();
        body = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        speed = game.enemy2Speed;
        detectionRadius = game.enemy2DetectionRadius;

    }

    // Update is called once per frame
    private void Update()
    {

        RaycastHit hit;

        if (Physics.SphereCast(camera.transform.position, detectionRadius, camera.transform.forward, out hit, 10000))
        //if (Physics.Raycast)
        {
            //FollowPlayer();
            dis = hit.distance;

            if (hit.rigidbody == body)
            {
                FollowPlayer();
                //dis = hit.distance;
            }
        }
        else
        {
            Debug.Log("STOP");
            dis = 10000;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(camera.transform.position, camera.transform.position + camera.transform.forward * dis, Color.red, 2);
        Gizmos.DrawWireSphere(camera.transform.position + camera.transform.forward * dis, detectionRadius);

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

// Barry Day, 11-23-20

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //new Transform transform;
    private CharacterController controller;
    //new BoxCollider collider;
    private Transform model;
    private Animator animator;
    //private ParticleSystem bloodfire;
    public ParticleSystem bloodfire;

    public GameObject vol;

    private Vector3 positionInitial;
    private Vector3 positionFinal;
    private bool flag = false;

    [Range(0.1f, 100)]
    public float speed;
    [HideInInspector]
    public bool alive = true;

    void Awake()
    {
        //transform = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        //collider = GetComponent<BoxCollider
        model = transform.GetChild(0);
        animator = GetComponentsInChildren<Animator>()[0];
        //bloodfire = GetComponentsInChildren<ParticleSystem>()[1];
    }

    void Update()
    {


        if (alive)
        {
            var delta = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
            controller.SimpleMove(delta);

            if (delta.magnitude > 0.1)
            {
                animator.Play("WalkState");
            }
            else
            {
                animator.Play("IdleState");
            }
        }
        else
        {
            if (!flag)
            {
                animator.enabled = false;
                bloodfire.Play();
                flag = true;
                Debug.Log("???");
            }

            StartDying();
        }

    }

    private void StartDying()
    {

        if (Random.Range(1, 100) > 90)
        {
            var rotation = Quaternion.Euler(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
            model.localRotation = rotation;
        }
    }
}

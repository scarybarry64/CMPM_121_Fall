using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform transform;
    private CharacterController controller;
    private BoxCollider collider;
    private Animator animator;

    private Vector3 positionInitial;
    private Vector3 positionFinal;

    [Range(0.1f, 100)]
    public float speed;

    void Start()
    {
        transform = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        collider = GetComponent<BoxCollider>();
        animator = transform.GetComponentsInChildren<Animator>()[0];
    }

    void Update()
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
}

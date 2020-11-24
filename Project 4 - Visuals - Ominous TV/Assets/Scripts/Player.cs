// Barry Day, 11-23-20
// Handles player control and status

using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Transform model;
    private Animator animator;
    private Vector3 positionInitial;
    private Vector3 positionFinal;
    private bool flag = false;

    [Range(0.1f, 100)]
    public float speed;
    [HideInInspector]
    public bool alive = true;
    public ParticleSystem bloodfire;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        model = transform.GetChild(0);
        animator = GetComponentsInChildren<Animator>()[0];
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
                bloodfire.Play(); // Let thy blood burn
                flag = true;
            }

            StartDying(); // And let thy become an offering to Him
        }

    }

    // Player starts twitching and shit, overwhelmed by the Blood God
    private void StartDying()
    {
        if (Random.Range(1, 100) > 90)
        {
            var rotation = Quaternion.Euler(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
            model.localRotation = rotation;
        }
    }
}

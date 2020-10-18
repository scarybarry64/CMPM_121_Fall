using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBall : MonoBehaviour
{

    [Range(0.1f, 10)] public float speed;

    [SerializeField] public CharacterController Controller;
    [SerializeField] public Camera CameraFirst;
    [SerializeField] public Camera CameraThird;

    private void Update()
    {
        Controller.SimpleMove(new Vector3(0, 0, speed * Input.GetAxis("Vertical")));

        if (Input.GetAxis("Horizontal") == 1)
        {
            Debug.Log("1");
        }
        else if (Input.GetAxis("Horizontal") == -1)
        {
            Debug.Log("-1");
        }

    }
}

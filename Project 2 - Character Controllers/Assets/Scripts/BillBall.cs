using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBall : MonoBehaviour
{

    [Range(0.1f, 10)] public float speed;
    [SerializeField] public CharacterController Controller;
    [SerializeField] public Camera CameraFirst;
    [SerializeField] public Camera CameraThird;
    public int camera = 1;

    private void Update()
    {


        if (camera == 1)
        {

            CameraFirst.depth = 1;

            if (Input.GetKey(KeyCode.A))
            {
                CameraFirst.transform.Rotate(0, -0.3f, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CameraFirst.transform.Rotate(0, 0.3f, 0);
            }
        }
        else
        {
            CameraFirst.depth = -1;

            Controller.SimpleMove(new Vector3(speed * Input.GetAxis("Horizontal"), 0, speed * Input.GetAxis("Vertical")));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            camera *= -1;
        }
    }
}

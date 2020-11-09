using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController controller;

    [Range(0.1f, 10)]
    public float speed;

    public int room = 1;

    public Camera[] cameras;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.SimpleMove(new Vector3(-Input.GetAxis("Horizontal") * speed, 0, -Input.GetAxis("Vertical") * speed));

        if (room == 3)
        {
            cameras[2].transform.position = new Vector3(cameras[2].transform.position.x, cameras[2].transform.position.y, transform.position.z);
        }
    }

    public void SetCamera(int cam)
    {
        if (cam == 1)
        {
            cameras[0].enabled = true;
            cameras[1].enabled = false;
            cameras[2].enabled = false;
        }
        else if (cam == 2)
        {
            cameras[0].enabled = false;
            cameras[1].enabled = true;
            cameras[2].enabled = false;
        }
        if (cam == 3)
        {
            cameras[0].enabled = false;
            cameras[1].enabled = false;
            cameras[2].enabled = true;
        }
    }
}

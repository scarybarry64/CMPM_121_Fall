using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController controller;

    [Range(0.1f, 10)]
    public float speed;

    public int room = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.SimpleMove(new Vector3(-Input.GetAxis("Horizontal") * speed, 0, -Input.GetAxis("Vertical") * speed));
    }
}

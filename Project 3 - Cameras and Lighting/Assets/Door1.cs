using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Player>() != null)
        {


            if (player.room == 1)
            {
                Debug.Log("Room 2");

                player.room = 2;
            }
            else if (player.room == 2)
            {
                Debug.Log("Room 1");

                player.room = 1;
            }
        }
    }
}

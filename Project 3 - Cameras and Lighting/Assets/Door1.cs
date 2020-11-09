using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public Player player;

    // Switch rooms/cameras when player exits door
    public void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Player>() != null)
        {
            if (player.room == 1)
            {
                Debug.Log("Room 2");

                player.room = 2;
                player.SetCamera(2);
            }
            else if (player.room == 2)
            {
                Debug.Log("Room 1");

                player.room = 1;
                player.SetCamera(1);
            }
        }
    }
}

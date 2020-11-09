using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public Player player;

    // Switch rooms/cameras when player exits door
    public void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Player>() != null)
        {
            if (player.room == 2)
            {
                Debug.Log("Room 3");

                player.room = 3;
                player.SetCamera(3);
            }
            else if (player.room == 3)
            {
                Debug.Log("Room 2");

                player.room = 2;
                player.SetCamera(2);
            }
        }
    }
}

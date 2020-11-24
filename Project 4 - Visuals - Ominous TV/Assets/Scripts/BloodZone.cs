// Barry Day, 11-23-20
// Handles the "Blood Zone", the area around the TV
// Getting too close results in awfulness

using System.Collections;
using UnityEngine;

public class BloodZone : MonoBehaviour
{
    public Player player;
    public GameObject vhs1, vhs2;

    void Awake()
    {
        vhs1.SetActive(true);
        vhs2.SetActive(false);
    }

    // Fucks up the player if they get too close
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            StartCoroutine(Kill());
        }
    }

    // Player becomes an offering to the Blood God
    private IEnumerator Kill()
    {
        player.alive = false;
        FindObjectOfType<AudioManager>().Play("Dying");
        yield return new WaitForSecondsRealtime(3f);
        FindObjectOfType<AudioManager>().Play("Dead");
        vhs1.SetActive(false);
        vhs2.SetActive(true);
    }
}

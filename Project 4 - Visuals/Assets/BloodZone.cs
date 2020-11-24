// Barry Day, 11-23-20

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodZone : MonoBehaviour
{
    public Player player;
    public GameObject vhs1, vhs2;

    // Start is called before the first frame update
    void Awake()
    {
        vhs1.SetActive(true);
        vhs2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("HERE");
            StartCoroutine(Kill());
        }
    }

    private IEnumerator Kill()
    {
        player.alive = false;
        FindObjectOfType<AudioManager>().Play("Dying");
        yield return new WaitForSecondsRealtime(1.7f);
        FindObjectOfType<AudioManager>().Play("Dead");
        vhs1.SetActive(false);
        vhs2.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodZone : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Awake()
    {

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
        yield return new WaitForSecondsRealtime(4f);
        Debug.Log("COMMENCE");
    }
}

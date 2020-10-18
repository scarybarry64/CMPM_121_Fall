// By Barry Day, 10-18-20
// This script handles the powerup, "Pete Power"

using UnityEngine;

public class PetePower : MonoBehaviour
{
    public BillBall Bill;

    private MeshRenderer Mesh;

    private void Awake()
    {
        Mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
        // Only visible in first person
        if (Bill.camera == 1)
        {
            Mesh.enabled = true;
            transform.Rotate(Random.Range(0.1f, 180), Random.Range(0.1f, 180), Random.Range(0.1f, 180));
        }
        else
        {
            Mesh.enabled = false;
        }
    }

    // Destroyed when picked up
    private void OnTriggerEnter(Collider Thing)
    {
        if (Thing.tag == "BillBall")
        {
            Bill.petePowerLevel += 1;
            Object.Destroy(gameObject, 0f);
        }
    }
}

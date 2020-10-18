// By Barry Day, 10-18-20
// This script handles the bad guy, "Bob Box"

using UnityEngine;

public class BobBox : MonoBehaviour
{
    [Range(0.1f, 20)] public float speed;
    public BillBall Bill;

    private Rigidbody Body;
    private Vector3 Movement;

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        // Code from: https://www.youtube.com/watch?v=4Wh22ynlLyk
        // Constantly faces the player, very spooky
        Vector3 direction = Bill.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Body.rotation = Quaternion.Euler(0, angle, 0);
        direction.Normalize();
        Movement = direction;

        // Stop following the player if they win
        if (Bill.state != 1)
        {
            FollowBill(Movement);
        }
    }

    // Code from: https://www.youtube.com/watch?v=4Wh22ynlLyk
    // Follows the player like a filthy scoundrel
    private void FollowBill(Vector3 direction)
    {
        Body.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}

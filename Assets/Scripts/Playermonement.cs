using UnityEngine;

public class Playermonement : MonoBehaviour
{
    public Rigidbody rb;
    public float forward = 100f;
    public float sideforce = 500f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * 100.0f * Time.deltaTime, 0, 0, ForceMode.Impulse);
        rb.AddForce(0, 0, Input.GetAxis("Vertical") * 100.0f * Time.deltaTime, ForceMode.Impulse);
    }
}

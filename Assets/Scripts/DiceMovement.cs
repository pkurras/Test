
using UnityEngine;

public class DiceMovement : MonoBehaviour
{
    public float speedMultiplier = 1.0f;
    public Vector3 DiceOffset;
    private Rigidbody OwnRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        OwnRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float TimeMul = Time.deltaTime * 200.0f;
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(Random.Range(0, TimeMul), Random.Range(0, TimeMul), Random.Range(0, TimeMul)));

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(mouseRay, out hit, 1 << 8)) 
        {
            Vector3 destination = hit.point + DiceOffset;
            OwnRigidbody.velocity = (destination - transform.position)*speedMultiplier;
        }
        else
        {
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
        }
    }
    public void Reset()
    {
        transform.position = Vector3.zero + Vector3.up * 5.0f;
    }
}

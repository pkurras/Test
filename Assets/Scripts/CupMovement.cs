
using UnityEngine;

public class CupMovement : MonoBehaviour
{
    public float speedMultiplier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(mouseRay, out hit, 1 << 8)) 
        {
            Vector3 destination = hit.point;
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = (destination - transform.position)*speedMultiplier;
        }
        else
        {
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
        }
        

    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermonement : MonoBehaviour
{
    public Rigidbody rb;
    public float forward = 100f;
    public float sideforce = 500f;




    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forward * Time.deltaTime, ForceMode.VelocityChange);

        }


        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forward * Time.deltaTime, ForceMode.VelocityChange);

        }


        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }


        if (Input.GetKey("d"))
        {
            rb.AddForce(sideforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }



    }
}

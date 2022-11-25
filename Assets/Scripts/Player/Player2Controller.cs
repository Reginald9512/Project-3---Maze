using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float xForce = 10.0f;
    public float zForce = 10.0f;
    public float yForce = 500.0f;
 
    void FixedUpdate()
    { 
        float x = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = x - xForce;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = x + xForce;
        }  

        float z = 0.0f;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            z = z - zForce;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            z = z + zForce;
        }

        float y = 0.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = yForce;
        }

        GetComponent<Rigidbody>().AddForce(x, y, z);
    }
}

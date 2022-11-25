using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float xForce = 10.0f;
    public float zForce = 10.0f;
    public float yForce = 500.0f;

    void FixedUpdate()
    {
        float x = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            x = x - xForce;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = x + xForce;
        }

        float z = 0.0f;

        if (Input.GetKey(KeyCode.S))
        {
            z = z - zForce;
        }

        if (Input.GetKey(KeyCode.W))
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

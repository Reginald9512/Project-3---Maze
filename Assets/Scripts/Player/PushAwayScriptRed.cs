using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAwayScriptRed : MonoBehaviour
{
    public GameObject objectToPush;
    public float pushForce = 50.0f;

    private void Update()
    {
        if (Input.GetKeyDown("left shift"))
        {
            Vector3 pushDirection = objectToPush.transform.position - transform.position;

            pushDirection = pushDirection.normalized;

            objectToPush.GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}

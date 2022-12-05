using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    public GameObject enemy1;
    public float speed = 1.19f;
    public Vector3 enemy1Position1;
    public Vector3 enemy1Position2;

    void Start()
    {
        enemy1Position1 = new Vector3(-28, 1, 28);
        enemy1Position2 = new Vector3(-28, 1, -28);
    }

    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(enemy1Position1, enemy1Position2, time);
    }
}

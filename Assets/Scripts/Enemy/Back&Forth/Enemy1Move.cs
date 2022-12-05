using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{
    public GameObject enemy1;
    public float speed = 1.19f;
    public Vector3 enemy1Position1;
    public Vector3 enemy1Position2;

    void Start()
    {
        enemy1Position1 = new Vector3(-21, 3, 44);
        enemy1Position2 = new Vector3(-32, 3, 63);
    }

    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(enemy1Position1, enemy1Position2, time);
    }
}

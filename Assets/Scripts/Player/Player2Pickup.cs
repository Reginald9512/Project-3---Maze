using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player2Pickup : MonoBehaviour
{
    public int greenKeyScoreNumber;

    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject player2Teleporter;
    public GameObject player2Win;
    public GameObject player1;
    public GameObject greenKey1;
    public GameObject greenKey2;
    public GameObject greenKey3;
    public GameObject greenKey4;

    public GameObject emptyGK1;
    public GameObject emptyGK2;
    public GameObject emptyGK3;
    public GameObject emptyGK4;
    public GameObject fullGK1;
    public GameObject fullGK2;
    public GameObject fullGK3;
    public GameObject fullGK4;
    public GameObject locked;
    public GameObject unlocked;

    public AudioSource audioManager;
    public AudioClip keyPickup;
    public AudioClip deathSound;

    public Transform player2StartPosition;

    private void Start()
    {
        greenKeyScoreNumber = 0;

        GetComponent<Player2Controller>().enabled = true;
    }

    private void Update()
    {
        if (greenKeyScoreNumber == 4)
        {
            player2Teleporter.SetActive(true);
        }

        if (greenKeyScoreNumber < 4)
        {
            player2Teleporter.SetActive(false);
        }

        //GreenScore UI Image
        if (greenKeyScoreNumber == 0)
        {
            emptyGK1.SetActive(true);
            emptyGK2.SetActive(true);
            emptyGK3.SetActive(true);
            emptyGK4.SetActive(true);
            locked.SetActive(true);
            unlocked.SetActive(false);
            fullGK1.SetActive(false);
            fullGK2.SetActive(false);
            fullGK3.SetActive(false);
            fullGK4.SetActive(false);
        }
        if (greenKeyScoreNumber == 1)
        {
            fullGK1.SetActive(true);
            emptyGK1.SetActive(false);
        }
        if (greenKeyScoreNumber == 2)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            emptyGK1.SetActive(false);
            emptyGK2.SetActive(false);
        }
        if (greenKeyScoreNumber == 3)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(true);
            emptyGK1.SetActive(false);
            emptyGK2.SetActive(false);
            emptyGK3.SetActive(false);
        }
        if (greenKeyScoreNumber == 4)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(true);
            fullGK4.SetActive(true);
            unlocked.SetActive(true);
            emptyGK1.SetActive(false);
            emptyGK2.SetActive(false);
            emptyGK3.SetActive(false);
            emptyGK4.SetActive(false);
            locked.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (name.Contains("GreenPlayer2"))
        {
            if (collision.gameObject.tag == "GreenKey")
            {
                collision.gameObject.SetActive(false);

                audioManager.PlayOneShot(keyPickup);

                greenKeyScoreNumber += 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Teleporter2"))
        {
            player2Win.SetActive(true);

            GetComponent<Player2Controller>().enabled = false;

            player1.GetComponent<Player1Controller>().enabled = false;

            gameObject.SetActive(false);

            player1.SetActive(false);

            enemy1.SetActive(false);
            enemy2.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.position = player2StartPosition.position;

            greenKeyScoreNumber = 0;

            audioManager.PlayOneShot(deathSound);

            greenKey1.SetActive(true);
            greenKey2.SetActive(true);
            greenKey3.SetActive(true);
            greenKey4.SetActive(true);
        }
    }
}

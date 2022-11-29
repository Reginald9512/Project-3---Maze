using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player2PickupHard : MonoBehaviour
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
    public GameObject greenKey5;
    public GameObject greenKey6;

    public GameObject emptyGK1;
    public GameObject emptyGK2;
    public GameObject emptyGK3;
    public GameObject emptyGK4;
    public GameObject emptyGK5;
    public GameObject emptyGK6;
    public GameObject fullGK1;
    public GameObject fullGK2;
    public GameObject fullGK3;
    public GameObject fullGK4;
    public GameObject fullGK5;
    public GameObject fullGK6;
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
        if (greenKeyScoreNumber == 6)
        {
            player2Teleporter.SetActive(true);
        }

        if (greenKeyScoreNumber < 6)
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
            emptyGK5.SetActive(true);
            emptyGK6.SetActive(true);
            fullGK1.SetActive(false);
            fullGK2.SetActive(false);
            fullGK3.SetActive(false);
            fullGK4.SetActive(false);
            fullGK5.SetActive(false);
            fullGK6.SetActive(false);
            locked.SetActive(true);
            unlocked.SetActive(false);
        }
        if (greenKeyScoreNumber == 1)
        {
            fullGK1.SetActive(true);
        }
        if (greenKeyScoreNumber == 2)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
        }
        if (greenKeyScoreNumber == 3)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(true);
        }
        if (greenKeyScoreNumber == 4)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(true);
            fullGK4.SetActive(true);
        }
        if (greenKeyScoreNumber == 5)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(true);
            fullGK4.SetActive(true);
            fullGK5.SetActive(true);
        }
        if (greenKeyScoreNumber == 6)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(true);
            fullGK4.SetActive(true);
            fullGK5.SetActive(true);
            fullGK6.SetActive(true);
            unlocked.SetActive(true);
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
            greenKey5.SetActive(true);
            greenKey6.SetActive(true);
        }
    }
}

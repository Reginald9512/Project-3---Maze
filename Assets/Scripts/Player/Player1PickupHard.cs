using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player1PickupHard : MonoBehaviour
{
    public int redKeyScoreNumber;

    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject player1Teleporter;
    public GameObject player1Win;
    public GameObject player2;
    public GameObject redKey1;
    public GameObject redKey2;
    public GameObject redKey3;
    public GameObject redKey4;
    public GameObject redKey5;
    public GameObject redKey6;

    public GameObject emptyRK1;
    public GameObject emptyRK2;
    public GameObject emptyRK3;
    public GameObject emptyRK4;
    public GameObject emptyRK5;
    public GameObject emptyRK6;
    public GameObject fullRK1;
    public GameObject fullRK2;
    public GameObject fullRK3;
    public GameObject fullRK4;
    public GameObject fullRK5;
    public GameObject fullRK6;
    public GameObject locked;
    public GameObject unlocked;

    public AudioSource audioManager;
    public AudioClip keyPickup;
    public AudioClip deathSound;

    public Transform player1StartPosition;

    public void Start()
    {
        redKeyScoreNumber = 0;
        
        GetComponent<Player1Controller>().enabled = true;
    }

    public void Update()
    {
        if(redKeyScoreNumber == 6)
        {
            player1Teleporter.SetActive(true);
        }

        if (redKeyScoreNumber < 6)
        {
            player1Teleporter.SetActive(false);
        }
        
        //RedScore UI Image
        if (redKeyScoreNumber == 0)
        {
            emptyRK1.SetActive(true);
            emptyRK2.SetActive(true);
            emptyRK3.SetActive(true);
            emptyRK4.SetActive(true);
            emptyRK5.SetActive(true);
            emptyRK6.SetActive(true);
            fullRK1.SetActive(false);
            fullRK2.SetActive(false);
            fullRK3.SetActive(false);
            fullRK4.SetActive(false);
            fullRK5.SetActive(false);
            fullRK6.SetActive(false);
            locked.SetActive(true);
            unlocked.SetActive(false);
        }
        if (redKeyScoreNumber == 1)
        {
            fullRK1.SetActive(true);
        }
        if (redKeyScoreNumber == 2)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
        }
        if (redKeyScoreNumber == 3)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
            fullRK3.SetActive(true);
        }
        if (redKeyScoreNumber == 4)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
            fullRK3.SetActive(true);
            fullRK4.SetActive(true);
        }
        if (redKeyScoreNumber == 5)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
            fullRK3.SetActive(true);
            fullRK4.SetActive(true);
            fullRK5.SetActive(true);
        }
        if (redKeyScoreNumber == 6)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
            fullRK3.SetActive(true);
            fullRK4.SetActive(true);
            fullRK5.SetActive(true);
            fullRK6.SetActive(true);
            unlocked.SetActive(true);
            locked.SetActive(false);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (name.Contains("RedPlayer1"))
        {
            if (collision.gameObject.tag == "RedKey")
            {
                collision.gameObject.SetActive(false);

                audioManager.PlayOneShot(keyPickup);

                redKeyScoreNumber += 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Teleporter1"))
        {
            player1Win.SetActive(true);

            GetComponent<Player1Controller>().enabled = false;

            player2.GetComponent<Player2Controller>().enabled = false;

            gameObject.SetActive(false);

            player2.SetActive(false);

            enemy1.SetActive(false);
            enemy2.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.position = player1StartPosition.position;

            redKeyScoreNumber = 0;

            audioManager.PlayOneShot(deathSound);

            redKey1.SetActive(true);
            redKey2.SetActive(true);
            redKey3.SetActive(true);
            redKey4.SetActive(true);
            redKey5.SetActive(true);
            redKey6.SetActive(true);
        }
    }
}

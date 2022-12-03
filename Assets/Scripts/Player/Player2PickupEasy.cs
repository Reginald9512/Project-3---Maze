using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player2PickupEasy : MonoBehaviour
{
    public int greenKeyScoreNumber;

    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject player2Teleporter;
    public GameObject player2Win;
    public GameObject player1;
    public GameObject player2;
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
    public AudioClip fastTravel;

    public Transform player2StartPosition;
    public Transform fastTravel1;
    public Transform fastTravel2;

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
            fullGK1.SetActive(false);
            fullGK2.SetActive(false);
            fullGK3.SetActive(false);
            fullGK4.SetActive(false);
            locked.SetActive(true);
            unlocked.SetActive(false);
        }
        if (greenKeyScoreNumber == 1)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(false);
            fullGK3.SetActive(false);
            fullGK4.SetActive(false);
        }
        if (greenKeyScoreNumber == 2)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(false);
            fullGK4.SetActive(false);
        }
        if (greenKeyScoreNumber == 3)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(true);
            fullGK4.SetActive(false);
        }
        if (greenKeyScoreNumber == 4)
        {
            fullGK1.SetActive(true);
            fullGK2.SetActive(true);
            fullGK3.SetActive(true);
            fullGK4.SetActive(true);
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
            //GetComponent<Player2Controller>().enabled = false;

            //player1.GetComponent<Player1Controller>().enabled = false;

            //gameObject.SetActive(false);

            //player1.SetActive(false);

            //enemy1.SetActive(false);
            //enemy2.SetActive(false);

            SceneManager.LoadScene(5);
        }

        if (other.gameObject.CompareTag("Fast Travel 1"))
        {
            player2.transform.position = fastTravel2.position;

            audioManager.PlayOneShot(fastTravel);
        }
        if (other.gameObject.CompareTag("Fast Travel 2"))
        {
            player2.transform.position = fastTravel1.position;

            audioManager.PlayOneShot(fastTravel);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //0
            if (greenKey1.activeSelf == true && greenKey2.activeSelf == true && greenKey3.activeSelf == true && greenKey4.activeSelf == true)
            {
                greenKeyScoreNumber += 0;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //1
            if (greenKey1.activeSelf == false && greenKey2.activeSelf == true && greenKey3.activeSelf == true && greenKey4.activeSelf == true)
            {
                greenKey1.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == true && greenKey2.activeSelf == false && greenKey3.activeSelf == true && greenKey4.activeSelf == true)
            {
                greenKey2.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == true && greenKey2.activeSelf == true && greenKey3.activeSelf == false && greenKey4.activeSelf == true)
            {
                greenKey3.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == true && greenKey2.activeSelf == true && greenKey3.activeSelf == true && greenKey4.activeSelf == false)
            {
                greenKey4.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //2
            if (greenKey1.activeSelf == false && greenKey2.activeSelf == false && greenKey3.activeSelf == true && greenKey4.activeSelf == true)
            {
                greenKey1.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == false && greenKey2.activeSelf == true && greenKey3.activeSelf == false && greenKey4.activeSelf == true)
            {
                greenKey3.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == true && greenKey2.activeSelf == false && greenKey3.activeSelf == false && greenKey4.activeSelf == true)
            {
                greenKey2.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == false && greenKey2.activeSelf == true && greenKey3.activeSelf == true && greenKey4.activeSelf == false)
            {
                greenKey4.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == true && greenKey2.activeSelf == true && greenKey3.activeSelf == false && greenKey4.activeSelf == false)
            {
                greenKey3.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //3
            if (greenKey1.activeSelf == false && greenKey2.activeSelf == false && greenKey3.activeSelf == false && greenKey4.activeSelf == true)
            {
                greenKey2.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == false && greenKey2.activeSelf == true && greenKey3.activeSelf == false && greenKey4.activeSelf == false)
            {
                greenKey4.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == false && greenKey2.activeSelf == false && greenKey3.activeSelf == true && greenKey4.activeSelf == false)
            {
                greenKey2.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (greenKey1.activeSelf == true && greenKey2.activeSelf == false && greenKey3.activeSelf == false && greenKey4.activeSelf == false)
            {
                greenKey3.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //4
            if (greenKey1.activeSelf == false && greenKey2.activeSelf == false && greenKey3.activeSelf == false && greenKey4.activeSelf == false)
            {
                greenKey1.SetActive(true);
                greenKeyScoreNumber -= 1;
                transform.position = player2StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
        }
    }
}

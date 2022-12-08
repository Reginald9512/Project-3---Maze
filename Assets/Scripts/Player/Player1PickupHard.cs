using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player1PickupHard : MonoBehaviour
{
    public int redKeyScoreNumber;
    
    public GameObject player1Teleporter;
    public GameObject player1Win;
    public GameObject player1;
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
    public AudioClip fastTravel;

    public Transform player1StartPosition;
    public Transform fastTravel1;
    public Transform fastTravel2;
    public Transform fastTravel3;
    public Transform fastTravel4;

    public GameObject redKey1Found;
    public GameObject redKey2Found;
    public GameObject redKey3Found;
    public GameObject redKey4Found;
    public GameObject redKey5Found;
    public GameObject redKey6Found;
    public AnimationClip fadeOutAnimation;
    public float waitDuration = 1.0f;

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
            redKey1Found.SetActive(false);
            redKey2Found.SetActive(false);
            redKey3Found.SetActive(false);
            redKey4Found.SetActive(false);
            redKey5Found.SetActive(false);
            redKey6Found.SetActive(false);
        }
        if (redKeyScoreNumber == 1)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(false);
            fullRK3.SetActive(false);
            fullRK4.SetActive(false);
            fullRK5.SetActive(false);
            fullRK6.SetActive(false);
        }
        if (redKeyScoreNumber == 2)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
            fullRK3.SetActive(false);
            fullRK4.SetActive(false);
            fullRK5.SetActive(false);
            fullRK6.SetActive(false);
        }
        if (redKeyScoreNumber == 3)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
            fullRK3.SetActive(true);
            fullRK4.SetActive(false);
            fullRK5.SetActive(false);
            fullRK6.SetActive(false);
        }
        if (redKeyScoreNumber == 4)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
            fullRK3.SetActive(true);
            fullRK4.SetActive(true);
            fullRK5.SetActive(false);
            fullRK6.SetActive(false);
        }
        if (redKeyScoreNumber == 5)
        {
            fullRK1.SetActive(true);
            fullRK2.SetActive(true);
            fullRK3.SetActive(true);
            fullRK4.SetActive(true);
            fullRK5.SetActive(true);
            fullRK6.SetActive(false);
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

                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        if (redKeyScoreNumber == 1)
        {
            redKey1Found.SetActive(true);

            yield return new WaitForSeconds(2.0f);

            redKey1Found.SetActive(false);
        }
        if (redKeyScoreNumber == 2)
        {
            redKey2Found.SetActive(true);

            yield return new WaitForSeconds(2.0f);

            redKey2Found.SetActive(false);
        }
        if (redKeyScoreNumber == 3)
        {
            redKey3Found.SetActive(true);

            yield return new WaitForSeconds(2.0f);

            redKey3Found.SetActive(false);
        }
        if (redKeyScoreNumber == 4)
        {
            redKey4Found.SetActive(true);

            yield return new WaitForSeconds(2.0f);

            redKey4Found.SetActive(false);
        }
        if (redKeyScoreNumber == 5)
        {
            redKey5Found.SetActive(true);

            yield return new WaitForSeconds(2.0f);

            redKey5Found.SetActive(false);
        }
        if (redKeyScoreNumber == 6)
        {
            redKey6Found.SetActive(true);

            yield return new WaitForSeconds(2.0f);

            redKey6Found.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Teleporter1"))
        {
            SceneManager.LoadScene(6);
        }

        if (other.gameObject.CompareTag("Fast Travel 1"))
        {
            player1.transform.position = fastTravel2.position;

            audioManager.PlayOneShot(fastTravel);
        }
        if (other.gameObject.CompareTag("Fast Travel 2"))
        {
            player1.transform.position = fastTravel1.position;

            audioManager.PlayOneShot(fastTravel);
        }
        if (other.gameObject.CompareTag("Fast Travel 3"))
        {
            player1.transform.position = fastTravel4.position;

            audioManager.PlayOneShot(fastTravel);
        }
        if (other.gameObject.CompareTag("Fast Travel 4"))
        {
            player1.transform.position = fastTravel3.position;

            audioManager.PlayOneShot(fastTravel);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //0
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKeyScoreNumber += 0;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //1
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey1.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //2
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey1.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //3
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey1.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey1.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey1.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //4
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == true)
            {
                redKey1.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey1.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //5
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == true)
            {
                redKey1.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == true && redKey6.activeSelf == false)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == true && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey3.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == true && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey4.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == false && redKey2.activeSelf == true && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey5.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            if (redKey1.activeSelf == true && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey6.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
            //6
            if (redKey1.activeSelf == false && redKey2.activeSelf == false && redKey3.activeSelf == false && redKey4.activeSelf == false && redKey5.activeSelf == false && redKey6.activeSelf == false)
            {
                redKey2.SetActive(true);
                redKeyScoreNumber -= 1;
                transform.position = player1StartPosition.position;
                audioManager.PlayOneShot(deathSound);
            }
        }
    }
}

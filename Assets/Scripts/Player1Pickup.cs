using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player1Pickup : MonoBehaviour
{
    public TextMeshProUGUI redKeyScore;
    public int redKeyScoreNumber;

    public GameObject player1Teleporter;
    public GameObject player1Win;
    public GameObject Player2;

    public AudioSource audioManager;
    public AudioClip key;

    public void Start()
    {
        redKeyScoreNumber = 0;
        redKeyScore.text = redKeyScoreNumber.ToString();

        GetComponent<Player1Controller>().enabled = true;
    }

    public void Update()
    {
        redKeyScore.text = redKeyScoreNumber.ToString();

        if(redKeyScoreNumber == 4)
        {
            player1Teleporter.SetActive(true);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (name.Contains("RedPlayer1"))
        {
            if (collision.gameObject.tag == "RedKey")
            {
                Destroy(collision.gameObject);

                audioManager.PlayOneShot(key);

                redKeyScoreNumber += 1;
                redKeyScore.text = redKeyScoreNumber.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Teleporter1"))
        {
            player1Win.SetActive(true);

            GetComponent<Player1Controller>().enabled = false;

            Player2.GetComponent<Player2Controller>().enabled = false;

            gameObject.SetActive(false);

            Player2.SetActive(false);
        }
    }
}

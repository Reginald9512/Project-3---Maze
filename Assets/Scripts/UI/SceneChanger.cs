using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public AudioSource audioManager;

    public AudioClip buttonPress;

    public GameObject difficultyPanel;

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);

        audioManager.PlayOneShot(buttonPress);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");

        audioManager.PlayOneShot(buttonPress);
    }

    public void openDifficultyPanel()
    {
        difficultyPanel.SetActive(true);
    }

    public void closeDifficultyPanel()
    {
        difficultyPanel.SetActive(false);
    }
}

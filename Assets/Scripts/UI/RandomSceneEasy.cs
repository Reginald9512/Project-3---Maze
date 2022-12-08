using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSceneEasy : MonoBehaviour
{
    public Animator crossFade;

    public void LoadRandomScene()
    {
        crossFade.SetTrigger("Start");

        int index = Random.Range(2, 5);

        SceneManager.LoadScene(index);
    }
}

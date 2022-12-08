using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSceneHard : MonoBehaviour
{
    public Animator crossFade;

    public void LoadRandomScene()
    {
        crossFade.SetTrigger("Start");

        int index = Random.Range(5, 8);

        SceneManager.LoadScene(index);
    }
}

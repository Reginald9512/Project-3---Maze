using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContinuer : MonoBehaviour
{
    private static AudioContinuer instance = null;

    public static AudioContinuer Instance
    {
        get { return instance; }
    }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEngine.ParticleSystem;

public class PushAwayScriptGreen : MonoBehaviour
{
    public GameObject objectToPush;
    public float pushForce = 50.0f;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public ParticleSystem particle4;
    public float VFXDuration = 1.0f;
    private bool isPlayingVFX = false;

    void Start()
    {
        particle1.Stop();
        particle2.Stop();
        particle3.Stop();
        particle4.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown("right shift") && !isPlayingVFX)
        {
            particle1.Play();
            particle2.Play();
            particle3.Play();
            particle4.Play();

            Vector3 pushDirection = objectToPush.transform.position - transform.position;

            pushDirection = pushDirection.normalized;

            objectToPush.GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);

            isPlayingVFX = true;

            StartCoroutine(WaitForVFX());
        }

        else if (Input.GetKeyUp("right shift") && isPlayingVFX)
        {
            particle1.Stop();
            particle2.Stop();
            particle3.Stop();
            particle4.Stop();
        }
    }

    IEnumerator WaitForVFX()
    {
        yield return new WaitForSeconds(VFXDuration);
        isPlayingVFX = false;
    }
}

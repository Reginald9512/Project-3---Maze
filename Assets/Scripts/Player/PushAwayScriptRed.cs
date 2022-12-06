using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEngine.ParticleSystem;

public class PushAwayScriptRed : MonoBehaviour
{
    public GameObject objectToPush;
    public float pushForce = 50.0f;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public ParticleSystem particle4;
    public ParticleSystem particle5;
    public ParticleSystem particle6;
    public ParticleSystem particle7;
    public ParticleSystem particle8;
    public ParticleSystem particle9;
    public ParticleSystem particle10;
    public ParticleSystem particle11;
    public ParticleSystem particle12;
    public ParticleSystem particle13;
    public ParticleSystem particle14;
    public float VFXDuration = 1.0f;
    private bool isPlayingVFX = false;

    void Start()
    {
        particle1.Stop();
        particle2.Stop();
        particle3.Stop();
        particle4.Stop();
        particle5.Stop();
        particle6.Stop();
        particle7.Stop();
        particle8.Stop();
        particle9.Stop();
        particle10.Stop();
        particle11.Stop();
        particle12.Stop();
        particle13.Stop();
        particle14.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown("left shift") && !isPlayingVFX)
        {
            particle1.Play();
            particle2.Play();
            particle3.Play();
            particle4.Play();
            particle5.Play();
            particle6.Play();
            particle7.Play();
            particle8.Play();
            particle9.Play();
            particle10.Play();
            particle11.Play();
            particle12.Play();
            particle13.Play();
            particle14.Play();

            Vector3 pushDirection = objectToPush.transform.position - transform.position;

            pushDirection = pushDirection.normalized;

            objectToPush.GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);

            isPlayingVFX = true;

            StartCoroutine(WaitForVFX());
        }

        else if (Input.GetKeyUp("left shift") && isPlayingVFX)
        {
            particle1.Stop();
            particle2.Stop();
            particle3.Stop();
            particle4.Stop();
            particle5.Stop();
            particle6.Stop();
            particle7.Stop();
            particle8.Stop();
            particle9.Stop();
            particle10.Stop();
            particle11.Stop();
            particle12.Stop();
            particle13.Stop();
            particle14.Stop();
        }
    }

    IEnumerator WaitForVFX()
    {
        yield return new WaitForSeconds(VFXDuration);
        isPlayingVFX = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{
 [SerializeField]
 private  Rigidbody rb3d;

 [SerializeField]
 private float strength = 16, delay = 0.15f;

 public UnityEvent OnBegin, OnDone;

 public void PlayFeedback(GameObject sender)
 {
	 StopAllCoroutines();
	 OnBegin?.Invoke();
	 Vector2 direction = (transform.position - sender.transform.position).normalized;
	 rb3d.AddForce(direction*strength,ForceMode.Impulse);
	 StartCoroutine(Reset());
 }

 private IEnumerator Reset()
 {
	 yield return new WaitForSeconds(delay);
	 rb3d.velocity = Vector3.zero;
	 OnDone?.Invoke();
 }
}

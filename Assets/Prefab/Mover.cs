using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	public float lifetime;
	public float upScale;

	void Start ()
	{
		Rigidbody rb = (Rigidbody)GetComponent(typeof(Rigidbody));
		rb.velocity =  transform.forward * speed + transform.up * upScale;
	}

	void  Awake ()
	{
		Destroy(gameObject, lifetime);
	}
}
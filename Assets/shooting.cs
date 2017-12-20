using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary12
{
	public float xMin, xMax, zMin, zMax;
}

public class shoting : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary12 boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update ()
	{
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

}
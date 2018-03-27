using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
	public float speed = 2.0f;

	bool allowRotation;

	void Start ()
	{
		allowRotation = false;
	}

	void Update ()
	{
		if (allowRotation) {
			transform.Rotate (-Vector3.forward, speed * Time.deltaTime);
		}	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			allowRotation = true;
		} else {	
			allowRotation = false;
		}
	}
}

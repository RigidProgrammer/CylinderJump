using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	[SerializeField]
	private GameObject player;

	private float offest;

	float _pos;

	void Start ()
	{
		offest = transform.position.x - player.transform.position.x;
	}

	void LateUpdate ()
	{
		_pos = player.transform.position.x;
		transform.position = new Vector3 (_pos + offest, transform.position.y, transform.position.z);
	}
}

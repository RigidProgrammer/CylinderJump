using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

	private Vector3 finalPosition;
	private Vector3 lastPosition;
	private float dragDistance;

	void Start ()
	{
		dragDistance = Screen.height * 15 / 100;
	}


	void Update ()
	{
		if (GameManager.Instance.isGameRunning) {
			if (Input.touchCount == 1 && ReferenceManager.Instance.playerScript.IsGrounded) {
				Touch touch = Input.GetTouch (0); 
				if (touch.phase == TouchPhase.Began) { 
					finalPosition = touch.position;
					lastPosition = touch.position;
				} else if (touch.phase == TouchPhase.Moved) { 
					lastPosition = touch.position;
				} else if (touch.phase == TouchPhase.Ended) { 
					lastPosition = touch.position; 
					if (Mathf.Abs (lastPosition.x - finalPosition.x) > dragDistance || Mathf.Abs (lastPosition.y - finalPosition.y) > dragDistance) {
						ReferenceManager.Instance.playerScript.DoubleJump ();
					} else {   
						ReferenceManager.Instance.playerScript.SingleJump ();
					}
				}
			}
		}
	}

}

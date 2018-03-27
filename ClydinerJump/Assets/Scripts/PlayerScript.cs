using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	[SerializeField]
	private Transform grounder;
	[SerializeField]
	private LayerMask ground;

	public float singleJumpSpeed = 0.1f;
	public float doubleJumpSpeed = 1.0f;
	public bool IsGrounded;

	Rigidbody2D _playerBody;
	float _distToGround;
	int _playerScore = 0;

	void Start ()
	{
		_playerBody = GetComponent<Rigidbody2D> ();
		_distToGround = GetComponent<Collider2D> ().bounds.extents.y;	
	}

	public void SingleJump ()
	{
		IsGrounded = false;
		_playerBody.velocity = Vector2.zero;
		_playerBody.AddForce (Vector2.up * singleJumpSpeed, ForceMode2D.Force);
		_playerBody.AddForce (Vector2.right * singleJumpSpeed, ForceMode2D.Force);
		ReferenceManager.Instance.obstacleSpawner.ObstacleNumber++;
		ReferenceManager.Instance.obstacleSpawner.OnObstacleSpawn.Invoke ();
	}

	public void DoubleJump ()
	{
		IsGrounded = false;
		_playerBody.velocity = Vector2.zero;
		_playerBody.AddForce (Vector2.up * doubleJumpSpeed, ForceMode2D.Force);
		_playerBody.AddForce (Vector2.right * doubleJumpSpeed, ForceMode2D.Force);
		ReferenceManager.Instance.obstacleSpawner.ObstacleNumber = ReferenceManager.Instance.obstacleSpawner.ObstacleNumber + 2;
		ReferenceManager.Instance.obstacleSpawner.OnObstacleSpawn.Invoke ();
	}

	public void SetPlayerVelocityToZero ()
	{
		_playerBody.velocity = Vector2.zero;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {

		}
		if (col.gameObject.tag == "Floor") {
			IsGrounded = true;
			ReferenceManager.Instance.uiManager.ActivatePanel ("LoseScreen");
			ReferenceManager.Instance.uiManager.DeactivatePanel ("Hud");
			GameManager.Instance.isGameRunning = false;
		}
		if (col.gameObject.tag == "Cylinder") {
			IsGrounded = true;
			_playerScore = _playerScore + 1;
			ReferenceManager.Instance.scoreManager.UpdateScore (_playerScore);
			ReferenceManager.Instance.scoreManager.SetScore ();
		}
	}


	void OnCollisionExit2D ()
	{
		IsGrounded = false;
	}
}

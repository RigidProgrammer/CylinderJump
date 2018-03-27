using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
	public bool isGameRunning;

	void Start ()
	{
		isGameRunning = false;
	}
}

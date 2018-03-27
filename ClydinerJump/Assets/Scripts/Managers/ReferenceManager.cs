using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviourSingleton<ReferenceManager>
{
	public PlayerScript playerScript;
	public ObstacleSpawner obstacleSpawner;
	public ScoreManager scoreManager;
	public UIManager uiManager;
}

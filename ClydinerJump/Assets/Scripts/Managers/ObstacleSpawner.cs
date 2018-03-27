using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class ObstacleSpawner : MonoBehaviour
{
	public float ThreshHoldValue;
	public float DistanceBetweenObstacles = 3.5f;
	public GameObject ObstaclePrefabOne, ObstaclePrefabTwo;
	public UnityEvent OnObstacleSpawn = new UnityEvent ();

	public int ObstacleNumber = 0;

	List<GameObject> ObstaclesReference = new List<GameObject> ();

	GameObject lastObstacle, defaultObstacle, currentObstacle;
	private Vector3 lastPlottedPosition;
	public int Count;

	void Awake ()
	{
		if (GameManager.Instance.isGameRunning) {
			currentObstacle = ObstaclePrefabOne;
			lastPlottedPosition = currentObstacle.transform.position;
			SpawnInitialObstacles ();

			OnObstacleSpawn.AddListener (delegate {
				if (ObstacleNumber >= 3) {
					ResetPosition ();
					ObstacleNumber = 0;
				}
			});
		}
	}

	public void SpawnInitialObstacles ()
	{
		for (int i = 0; i < Count; i++) {
			currentObstacle = Instantiate (ObstaclePrefabOne, lastPlottedPosition, currentObstacle.transform.rotation);
			lastPlottedPosition = new Vector3 (currentObstacle.transform.position.x + DistanceBetweenObstacles, Random.Range (-0.4f, 0.1f),
				currentObstacle.transform.position.z);

			ObstaclesReference.Add (currentObstacle);
		}
		defaultObstacle = ObstaclesReference [0];
		lastObstacle = ObstaclesReference [Count - 1];
	}

	void ResetPosition ()
	{
		lastPlottedPosition = new Vector3 (lastObstacle.transform.position.x + DistanceBetweenObstacles, Random.Range (-0.4f, 0.1f),
			lastObstacle.transform.position.z);
		defaultObstacle.transform.position = lastPlottedPosition;
		ObstaclesReference.RemoveAt (0);
		lastObstacle = defaultObstacle;
		ObstaclesReference.Add (lastObstacle);
		defaultObstacle = ObstaclesReference [0];
		lastObstacle = ObstaclesReference [Count - 1];
	}
}

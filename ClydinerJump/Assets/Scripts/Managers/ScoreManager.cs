using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text ScoreText;

	int currentScore = 0;

	public void SetScore ()
	{
		ScoreText.text = currentScore.ToString ();
	}

	public void UpdateScore (int score)
	{
		currentScore = currentScore + score;
	}

}

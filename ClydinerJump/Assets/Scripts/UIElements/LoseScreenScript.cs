using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenScript : MonoBehaviour
{

	public void Replay ()
	{
		Application.LoadLevel ("Main");
		UIManager.isReplayClicked = true;
		GameManager.Instance.isGameRunning = true;
	}

	public void Home ()
	{
		ReferenceManager.Instance.uiManager.DeactivatePanel ("LooseScreen");
		ReferenceManager.Instance.uiManager.ActivatePanel ("Menu");
		GameManager.Instance.isGameRunning = false;
	}
}

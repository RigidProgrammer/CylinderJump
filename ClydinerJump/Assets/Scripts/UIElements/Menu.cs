using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

	public void OnPlayButton ()
	{
		
		ReferenceManager.Instance.uiManager.ActivatePanel ("Hud");
		GameManager.Instance.isGameRunning = true;
		ReferenceManager.Instance.uiManager.DeactivatePanel ("Menu");
	}
}

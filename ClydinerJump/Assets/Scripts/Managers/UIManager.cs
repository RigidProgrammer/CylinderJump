using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static bool isReplayClicked;

	public List<GameObject> UiPanels = new List<GameObject> ();

	Dictionary<string, GameObject> PanelsReference = new Dictionary<string, GameObject> ();

	void Start ()
	{
		AddPanelsToPanelReferenc ();
		if (!isReplayClicked) {
			ActivatePanel ("Menu");
		} else {
			ActivatePanel ("Hud");
			isReplayClicked = false;
		}
	}


	void AddPanelsToPanelReferenc ()
	{
		foreach (var item in UiPanels) {
			item.SetActive (false);
			PanelsReference.Add (item.tag, item);
		}
	}

	public void ActivatePanel (string name)
	{
		PanelsReference [name].SetActive (true);
	}

	public void DeactivatePanel (string name)
	{
		PanelsReference [name].SetActive (false);
	}
}

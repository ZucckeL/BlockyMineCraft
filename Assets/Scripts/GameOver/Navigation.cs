using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {
	public GameObject developerPanel;
	public bool isClicked = false;
	
	public void CloseDeveloperPanel(){

	developerPanel.SetActive(false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NavigationMenu : MonoBehaviour {
		public GameObject developerPanel;
		public GameObject optionPanel;

		void Update(){
			Cursor.visible = true;
			Screen.lockCursor = false;
			if(Input.GetKeyDown(KeyCode.Escape)){
				developerPanel.SetActive(false);
				optionPanel.SetActive(false);
			}
			
		}
	public void OpenDeveloperPanel(){

		developerPanel.SetActive(true);
	}
	
	public void NewGame(){
		 SceneManager.LoadScene("MainScene");
	}
	public void OpenOptionPanel(){
		optionPanel.SetActive(true);
	}
	public void AppQuit(){
		Application.Quit();
	}
}

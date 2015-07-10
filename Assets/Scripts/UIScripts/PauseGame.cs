using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	public bool pauseGame = false;
	public GameObject PauseMenu;
	public GameObject OptionsMenu;
	public GameObject SalirDialog;

	void Start (){
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseGame = !pauseGame;

			if(pauseGame == true){
				Time.timeScale = 0;
				pauseGame = true;
				PauseMenu.SetActive(true);
			}
			if(pauseGame == false){
				Time.timeScale = 1;
				pauseGame = false;
				PauseMenu.SetActive(false);
				//OptionsMenu.SetActive(false);
				SalirDialog.SetActive(false);
			}

		}

	}
	public void setPause(bool b){
		pauseGame = b;
	}
}

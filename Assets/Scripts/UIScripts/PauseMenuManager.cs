using UnityEngine;
using System.Collections;

public class PauseMenuManager : MonoBehaviour {

	public GameObject optionsMenu;
	public GameObject pauseMenu;
	public GameObject ConfirmDialog;
	public PauseGame pauseGame;//script PauseGame del player para usar funcion setPause(bool b)


	// Update is called once per frame
	public void PauseMenuToOptions (Object myObject) {//place holder function ( la usaremos desde el inspector del boton OPTION
		optionsMenu.SetActive (true);
		pauseMenu.SetActive (false);
	}

	public void OptionsToPauseMenu (Object myObject) {
		optionsMenu.SetActive (false);
		pauseMenu.SetActive (true);
	}

	public void ResumeGame(Object myObject){
		Time.timeScale = 1;
		pauseGame.setPause (false);
		pauseMenu.SetActive(false);

		//optionsMenu.SetActive(false);
	}

	public void PauseToSalirDialog(Object myObject){
		pauseMenu.SetActive (false);
		ConfirmDialog.SetActive (true);
	}
	public void OnQuit(Object myObject){
		Application.LoadLevel ("EInicio");
		pauseGame.setPause (false);
	}

	public void SalirDialogToPause(Object myObject){
		pauseMenu.SetActive (true);
		ConfirmDialog.SetActive (false);
	}
}

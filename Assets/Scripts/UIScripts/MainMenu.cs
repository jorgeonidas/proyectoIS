using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject canvasLogin, canvasPrincipal;
	bool logeado = false;
	// Use this for initialization
	void Start () {
		canvasLogin.SetActive (true);
		canvasPrincipal.SetActive (false);
	}

	void Update () {
	
	}
	public void OnPushLogin(){
		logeado = true;
		canvasLogin.SetActive (false);
		canvasPrincipal.SetActive (true);
	}

	public void OnPushSalirALogin(){
		canvasLogin.SetActive (true);
		canvasPrincipal.SetActive (false);	
	}

	public void NuevaPartida(){
		Application.LoadLevel ("Nivel_01");

	}
}

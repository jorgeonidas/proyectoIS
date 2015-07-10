using UnityEngine;
using System.Collections;

public class Cofre : MonoBehaviour, Iinteractuable {
	Animator animCofre;
	// Use this for initialization
	void Start () {
		animCofre = GetComponent<Animator> ();
	}
	
	public void accion(){
		//abrimos el cofre
		animCofre.SetTrigger ("abrircofre");
	}
}

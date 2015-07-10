using UnityEngine;
using System.Collections;

public class JugadorAtaqueScript : MonoBehaviour, IAtaque {
	Animator anim,enemigoAnim;
	EnemigoSalud enemigoSaludScript;
	GameObject JugadorGobj;
	int dañoArma = 25;
	Cofre cofreScript;
	// Use this for initialization
	void Start () {
		JugadorGobj  = GameObject.FindGameObjectWithTag ("Jugador");
		anim = JugadorGobj.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		atacar ();
	}

	public void atacar(){
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger ("atacar");
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Enemigo")
		{
			Debug.Log("hit?");
			enemigoSaludScript = other.GetComponent<EnemigoSalud>();
			enemigoAnim = other.GetComponent<Animator>();
			enemigoSaludScript.recibirDaño(dañoArma);
			enemigoAnim.SetTrigger("golpeado");
			enemigoAnim.SetTrigger("repuesto");
		}
		if (other.tag == "Interactuable") {
			cofreScript = other.GetComponent<Cofre>();
			cofreScript.accion();
		}
	}
}

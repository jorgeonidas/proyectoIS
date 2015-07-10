using UnityEngine;
using System.Collections;

public class Puas : MonoBehaviour {
	int daño= 200;
	GameObject JugadorGobj;
	JugadorSalud jugadorSaludScritp;
	Animator JugadorAnim;
	// Use this for initialization
	void Start () {
		JugadorGobj = GameObject.FindGameObjectWithTag ("Jugador");
		jugadorSaludScritp = JugadorGobj.GetComponent<JugadorSalud> ();
		JugadorAnim = JugadorGobj.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D  coll){
		if (coll.gameObject.tag == "Jugador")
			JugadorAnim.SetTrigger("recibeDaño");
			jugadorSaludScritp.recibirDaño(daño);
		}
}


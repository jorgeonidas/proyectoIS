using UnityEngine;
using System.Collections;

public class trampaMecanicaScript : MonoBehaviour {
	int daño= 25;
	GameObject JugadorGobj;
	JugadorSalud jugadorSaludScritp;
	JugadorMovimientoScript JugadorMov;
	Animator JugadorAnim;
	Rigidbody2D JugadorRgb;
	Vector2 originalPos;
	void Start () {

		JugadorGobj = GameObject.FindGameObjectWithTag ("Jugador");
		jugadorSaludScritp = JugadorGobj.GetComponent<JugadorSalud> ();
		JugadorAnim = JugadorGobj.GetComponent<Animator> ();
		JugadorMov = JugadorGobj.GetComponent<JugadorMovimientoScript> ();
		JugadorRgb = JugadorGobj.GetComponent<Rigidbody2D>();
	}
	void Update () {

	}
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Jugador")) {
			Debug.Log("le di!: trampa mecanica");
			JugadorAnim.SetTrigger("recibeDaño");
			jugadorSaludScritp.recibirDaño(daño);
			JugadorRgb.AddForce(JugadorRgb.transform.localScale*-8, ForceMode2D.Impulse);
		}
	}	
}

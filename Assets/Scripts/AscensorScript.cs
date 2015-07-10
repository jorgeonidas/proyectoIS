using UnityEngine;
using System.Collections;

public class AscensorScript : MonoBehaviour {
	public Transform puntoFinal;
	public GameObject jugadorComoHijo;
	Transform escalaJugador;
	bool accionada;
	float velMov = 3f;
	void Start(){
		accionada = false;
	}
	// Update is called once per frame
	void Update () {
		ascender ();
	}

	void ascender(){
		if (accionada) {
			transform.position = Vector2.MoveTowards (transform.position, puntoFinal.position, velMov * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D  coll){
		if (coll.gameObject.CompareTag("Jugador")) {
			accionada = true;
			jugadorComoHijo = coll.gameObject;
			jugadorComoHijo.transform.parent = transform;
			Debug.Log(accionada);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		jugadorComoHijo.transform.parent = null;
	}
}

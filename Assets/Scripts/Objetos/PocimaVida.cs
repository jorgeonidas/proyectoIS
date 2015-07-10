using UnityEngine;
using System.Collections;

public class PocimaVida : MonoBehaviour, Icolectable<int> {
	int valorCuracion = 25 ;
	JugadorSalud jugadorSaludScript;

	public int colectar(){
		return valorCuracion;
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Jugador" ){
			jugadorSaludScript = other.GetComponent<JugadorSalud>();
			jugadorSaludScript.curarSalud(colectar());
			Destroy(this.gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class ArmaEspada : MonoBehaviour {
	Enemy enemyScript;
	Player playerScript;
	GameObject Jugador;
	int dañoEspada = 25;
	float knockBack = 250f;
	// Use this for initialization
	void Start (){
		Jugador = GameObject.FindGameObjectWithTag ("Jugador");
		playerScript = Jugador.GetComponent <Player> ();
	}
	void OnTriggerEnter2D(Collider2D other) {
		enemyScript = other.GetComponent<Enemy>();

		if (other.tag == "Enemigo") {
			//Debug.Log(playerScript.transform.localScale + "player");
			//Debug.Log(other.transform.localScale + "enemigo");
			enemyScript.tomarDaño(dañoEspada);
			if(Vector2.Dot(playerScript.transform.localScale,other.transform.localScale) <= 0){
				Debug.Log("Se miran");
				if(other.transform.localScale.x < 0){
					other.GetComponent<Rigidbody2D>().AddForce(other.transform.position.normalized * -knockBack);
				}else{
					other.GetComponent<Rigidbody2D>().AddForce(other.transform.position.normalized * knockBack);
				}
			}else{
				Debug.Log("enemigo de espaldas");
				if(other.transform.localScale.x < 0){
					other.GetComponent<Rigidbody2D>().AddForce(other.transform.position.normalized * knockBack);
				}else{
					other.GetComponent<Rigidbody2D>().AddForce(other.transform.position.normalized * -knockBack);
				}
			}

			if(enemyScript.getSalud() <= 0){
				//enemigo.morir();
				Destroy(other.gameObject);
			}
		}
	}
}

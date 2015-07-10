using UnityEngine;
using System.Collections;

public class EnemigoAtaque : MonoBehaviour, IAtaque {
	Animator anim;
	//bool alcance;
	float timer;
	public float tiempoEntreAtaques = 0.9f;
	public float knockbackTime = 0.9f;
	bool knockback;
	EnemigoMovimiento enemigoMovScript;
	Rigidbody2D enemigoRgb;
	int daño = 25;
	//jugador
	GameObject JugadorGobj;
	JugadorSalud jugadorSaludScritp;
	JugadorMovimientoScript jugadorMovScript;
	bool jugadorBloquea;
	Animator JugadorAnim;
	// Use this for initialization
	void Start () {
		knockback = false;
		anim = GetComponent<Animator> ();
		enemigoMovScript = GetComponent<EnemigoMovimiento> ();
		JugadorGobj = GameObject.FindGameObjectWithTag ("Jugador");
		jugadorSaludScritp = JugadorGobj.GetComponent<JugadorSalud> ();
		JugadorAnim = JugadorGobj.GetComponent<Animator> ();
		jugadorMovScript = JugadorGobj.GetComponent<JugadorMovimientoScript> ();
		enemigoRgb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (enemigoMovScript.alcance && timer >= tiempoEntreAtaques ) {
			atacar();
		}
	}

	public void atacar()
	{
		timer = 0f;
		if (jugadorSaludScritp.getSalud () > 0) {
			if(!knockback){
				anim.SetTrigger ("ataca");
			}else{
				knockback = false;
				enemigoMovScript.enabled = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Jugador") )
		{
			if(!jugadorMovScript.bloqueando)
			{ 
				jugadorSaludScritp.recibirDaño (daño);
				JugadorAnim.SetTrigger("recibeDaño");
			}else{
				//jugador no recibe el daño
				//knockback
				Debug.Log ("bloquea");
				enemigoRgb.AddForce(enemigoRgb.transform.localScale*-5, ForceMode2D.Impulse);
				enemigoMovScript.enabled = false;
				knockback = true;
			}
		}
	}
}

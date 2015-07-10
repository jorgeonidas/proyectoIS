using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Transform visionInicia, visionFin, alcanceInicia, alcanceFin;
	public bool avistado, mirandoDer, alcance;
	public GameObject alerta;
	public float velMov = 5;
	Animator anim;
	public GameObject player;
	public int salud = 75;
	RaycastHit2D queMiro;
	public float tiempoEntreAtaques = 0.9f;
	int daño = 15;
	float timer;
	GameObject Jugador;
	Player playerScript;

	Rigidbody2D enemyRigidbody;

	void Start () 
	{
		enemyRigidbody = GetComponent<Rigidbody2D> ();
		mirandoDer = true;
		anim = GetComponent<Animator> ();
		Jugador = GameObject.FindGameObjectWithTag ("Jugador");
		playerScript = Jugador.GetComponent <Player> ();//guarda la referencia de la vida del jugador
		//saludPlayer = playerScript.salud;
		InvokeRepeating ("patrullar", 0f,Random.Range(2,4));//repite la funcion indefinidamente desde que comienza el juego en un rango de 2 a 4 s
	}

	void Update () 
	{
		RayCasting ();
		Comportamiento ();
		RayCastingReach ();
		timer += Time.deltaTime;
		if (alcance && timer >= tiempoEntreAtaques && salud > 0) {
			atacar();
		}

	}

	void RayCasting()
	{
		Debug.DrawLine (visionInicia.position,visionFin.position,Color.red);
		if (Physics2D.Linecast (visionInicia.position, visionFin.position, 1 << LayerMask.NameToLayer ("Jugador"))) {
			queMiro = Physics2D.Linecast (visionInicia.position, visionFin.position,1 << LayerMask.NameToLayer("Jugador"));
			avistado = true;
		} else {
			avistado = false;
		}

	}
	void RayCastingReach(){
		Debug.DrawLine (alcanceInicia.position,alcanceFin.position,Color.yellow);
		if(Physics2D.Linecast (alcanceInicia.position, alcanceFin.position, 1 << LayerMask.NameToLayer ("Jugador"))) {
			queMiro = Physics2D.Linecast (visionInicia.position, visionFin.position,1 << LayerMask.NameToLayer("Jugador"));
			alcance = true;
		} else {
			alcance = false;
		}
	}

	void Comportamiento()
	{
		if (avistado == true) {
			alerta.SetActive (true);
			anim.SetBool("estaCaminando",true);
			transform.position = Vector2.MoveTowards(transform.position,queMiro.transform.position,velMov * Time.deltaTime);
		
		} else {

			alerta.SetActive (false);
			anim.SetBool("estaCaminando",false);
		}
	}
	void patrullar(){
		Vector2 vectorGiro;
		if (avistado == true || alcance == true) {
			return;
		} else {
			mirandoDer = !mirandoDer; //inviertes el booleano cada vez que ejecutas estra funcion
			if (mirandoDer == true) {
				vectorGiro = transform.localScale;
				vectorGiro.x = -1f;
				transform.localScale = vectorGiro;
			} else {
				vectorGiro = transform.localScale;
				vectorGiro.x = 1f;
				transform.localScale = vectorGiro;;
			}
		}
		//Debug.Log (transform.localScale + "enemi vector");
	}


	void atacar ()
	{
		//Debug.Log (playerScript.salud);
		timer = 0f;
		if (playerScript.getSalud () > 0) {
			anim.SetTrigger ("ataca");
		} else {
			playerScript.respawn();
		}
	}

	public void tomarDaño(int daño){
		anim.SetTrigger("golpeado");
		salud = salud - daño;
	}
	public int getSalud(){
		anim.SetTrigger("repuesto");
		return salud;
	}
	public void morir(){
		anim.SetBool ("estaMuerto", true);

	}


	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Jugador") )
		{
				playerScript.recibeDaño (daño);
		}
	}
}

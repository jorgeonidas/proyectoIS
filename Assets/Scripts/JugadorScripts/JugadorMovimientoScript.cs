using UnityEngine;
using System.Collections;

public class JugadorMovimientoScript : MonoBehaviour, IMovimiento{
	public int velocidad = 10;
	public float fuerzaSalto = 8f;
	Rigidbody2D JugadorRb;
	bool pisando = false;
	public bool bloqueando = false;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		movimiento ();
		rotar ();
		saltar ();
		bloquear ();
	}
	//sobreescribiendo de la Interfaz
	public void movimiento(){
		float h = Input.GetAxis ("Horizontal");
		if (h != 0) {
			anim.SetBool("estaCaminando", true);
			transform.position += transform.right * h * velocidad * Time.deltaTime;
		} else {
			anim.SetBool("estaCaminando", false);
		}
	}
	public void saltar(){
		if (Input.GetButtonDown("Jump"))
		{
			if(pisando)
			{
				GetComponent<Rigidbody2D>().AddForce(transform.up * fuerzaSalto, ForceMode2D.Impulse);
				//anim.SetTrigger("saltando");
				pisando = false;
			}else{

			}
		}
	}
	public void rotar(){
		Vector2 vectorGiro;
		if (Input.GetAxis ("Horizontal") < 0) {//girar el personaje
			vectorGiro = transform.localScale;
			vectorGiro.x = -1f;
			transform.localScale = vectorGiro;
		} else { 
			if (Input.GetAxis ("Horizontal") > 0) {//girar el personaje
				vectorGiro = transform.localScale;
				vectorGiro.x = 1f;
				transform.localScale = vectorGiro;
			}
		}
	}

	public void bloquear(){
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			bloqueando = true;
			anim.SetBool("bloqueando",bloqueando);
			velocidad = 0;
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift)) {
			bloqueando = false;
			anim.SetBool("bloqueando",bloqueando);
			velocidad = 6;
		}
	}

	void OnCollisionEnter2D(Collision2D  coll){
		if (coll.gameObject.tag == "Piso") {
			pisando = true;
		}
		if(coll.gameObject.tag == "caidaMortal"){
			//transform.position = respanwPoint.gameObject.transform.position;
		}
	}
}

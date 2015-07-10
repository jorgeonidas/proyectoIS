using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int velocidad = 8;
	public float fuerzaSalto = 8f;
	Animator anim;
	private bool pisando = true;
	Rigidbody2D playerRigidbody;
	Vector2 movimiento;
	//public GameObject arma;
	public GameObject respanwPoint;
	public int salud = 100;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		mover();
		girar ();
		saltar();
		StartCoroutine("swingSword");
	}

	public void mover()
	{
		float h = Input.GetAxis ("Horizontal");
		if (h != 0) {
			anim.SetBool("estaCaminando", true);
			transform.position += transform.right * h * velocidad * Time.deltaTime;
		} else {
			anim.SetBool("estaCaminando", false);
		}

	}
	IEnumerator swingSword() {
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger ("atacando");
			yield return new WaitForSeconds (0.48f);
			anim.SetTrigger ("noataca");
		}
	}

	public void respawn(){
		transform.position = respanwPoint.gameObject.transform.position;
		salud = 100;
	}
	public void girar(){
		Vector2 vectorGiro;
		if (Input.GetAxis ("Horizontal") < 0) {//girar el personaje
			vectorGiro = transform.localScale;
			vectorGiro.x = -1f;
			transform.localScale = vectorGiro;
		} else { 
			if (Input.GetAxis ("Horizontal") > 0) {//girar el personaje
				//Debug.Log ("move");
				vectorGiro = transform.localScale;
				vectorGiro.x = 1f;
				transform.localScale = vectorGiro;
			}
		}
		//Debug.Log (transform.localScale + "player vector");
	}

	public void recibeDaño(int daño){
		anim.SetTrigger ("golpeado");
		salud = salud - daño;
	}
	public int getSalud(){
		anim.SetTrigger ("repuesto");
		return salud;
	}

	public void saltar(){
		if (Input.GetButtonDown("Jump"))
		{
			if(pisando)
			{
				GetComponent<Rigidbody2D>().AddForce(transform.up * fuerzaSalto);
				//anim.SetTrigger("saltando");
				pisando = false;
			}
		}
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir){
		
		float timer = 0;
		
		while( knockDur > timer){
			
			timer+=Time.deltaTime;
			if(transform.localScale.x < 0){
				playerRigidbody.AddForce(new Vector3(knockbackDir.x * 5, knockbackDir.y * knockbackPwr, transform.position.z), ForceMode2D.Force);
			}else{
				playerRigidbody.AddForce(new Vector3(knockbackDir.x * -5, knockbackDir.y * knockbackPwr, transform.position.z), ForceMode2D.Force);
			}	
		}
		
		yield return 0;
		
	}

	void OnCollisionEnter2D(Collision2D  coll){
		if (coll.gameObject.tag == "Piso") {
			pisando = true;
		}
		if(coll.gameObject.tag == "caidaMortal"){
			transform.position = respanwPoint.gameObject.transform.position;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("checkPoint") )
		{
			respanwPoint.gameObject.transform.position = transform.position;
		}
	}
}

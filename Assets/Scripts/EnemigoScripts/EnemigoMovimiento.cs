using UnityEngine;
using System.Collections;

public class EnemigoMovimiento : MonoBehaviour, IMovimiento{
	public Transform visionInicia, visionFin, alcanceInicia, alcanceFin;
	public bool avistado, mirandoDer, alcance;
	public float velMov = 6;
	RaycastHit2D queMiro;
	Animator anim;
	private float rango;
	//private GameObject jugadorGob;
	private GameObject enemigoGob;
	
	void Start () {
		//jugadorGob = GameObject.FindGameObjectWithTag ("Jugador");
		mirandoDer = false;
		avistado = false;
		alcance = false;
		InvokeRepeating ("rotar", 0f,Random.Range(2,4));
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		RayCastingReach ();
		/*rango = Vector2.Distance (jugadorGob.transform.position, transform.position);
		if (rango < 10f) {
			avistado = true;
		} else {
			avistado = false;
		}*/
		movimiento ();

	}
	//rayo para perseguir
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
	//rayo para saber alcance
	void RayCastingReach(){
		Debug.DrawLine (alcanceInicia.position,alcanceFin.position,Color.yellow);
		if(Physics2D.Linecast (alcanceInicia.position, alcanceFin.position, 1 << LayerMask.NameToLayer ("Jugador"))) {
			queMiro = Physics2D.Linecast (visionInicia.position, visionFin.position,1 << LayerMask.NameToLayer("Jugador"));
			alcance = true;
		} else {
			alcance = false;
		}
	}

	public void movimiento()
	{
		if (avistado == true) {
			anim.SetBool("estaCaminando",true);
			transform.position = Vector2.MoveTowards(transform.position,queMiro.transform.position,velMov * Time.deltaTime);
			//transform.position = Vector2.MoveTowards(transform.position,jugadorGob.transform.position,velMov * Time.deltaTime);
			
		} else {
			anim.SetBool("estaCaminando",false);
		}
	}
	public void rotar()
	{
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
	}
	public void saltar()
	{
		// por ahora no
	}

	public void bloquear(){
		//este pana no bloquea
	}

}

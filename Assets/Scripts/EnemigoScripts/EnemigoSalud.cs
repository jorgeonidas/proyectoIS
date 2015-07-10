using UnityEngine;
using System.Collections;

public class EnemigoSalud : MonoBehaviour, ISalud<int> {
	public int saludEnemigo = 75;
	Animator anim;
	EnemigoMovimiento eneMovScript;
	void Start () {
		anim = GetComponent<Animator> ();
		eneMovScript = GetComponent<EnemigoMovimiento>();
	}
	
	// Update is called once per frame
	void Update () {
		if (saludEnemigo <= 0) {
			StartCoroutine (morir ());
		}
	}

	public void recibirDaño(int daño){
		saludEnemigo -= daño;
		Debug.Log (saludEnemigo);
	}

	public void curarSalud(int curacion){
		saludEnemigo += curacion;
	}

	public IEnumerator morir(){
		anim.SetTrigger("morir");
		eneMovScript.enabled = false;
		yield return new WaitForSeconds (1.5f);
		Destroy (gameObject);

	}

}

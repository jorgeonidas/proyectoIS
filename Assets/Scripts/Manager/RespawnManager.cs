using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour {
	public Transform[] spawnPoints;
	GameObject JugadorObj;
	JugadorSalud JSaludScript;
	int childIndex;
	// Use this for initialization
	void Start () {
		childIndex = 0;
		JugadorObj  = GameObject.FindGameObjectWithTag ("Jugador");
		JSaludScript = JugadorObj.GetComponent<JugadorSalud> ();
	}
	
	// Update is called once per frame
	void Update () {
		respawn ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Jugador")
		{
			Debug.Log("pase por un spawn point");
		}
	}

	public void setChildIndex(int i){
		childIndex = i;
		Debug.Log (childIndex);
	}

	public void respawn(){
		if (JSaludScript.getMuerto ()) {
			JugadorObj.transform.position = spawnPoints[childIndex].position;
			JSaludScript.setMuerto(false);
		}
	}
}

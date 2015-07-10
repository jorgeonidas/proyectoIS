using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public int index;
	//(GameObject padreO;
	RespawnManager PadreScript;
	// Use this for initialization
	void Start () {
		PadreScript = GameObject.FindGameObjectWithTag ("SpawnManager").GetComponent<RespawnManager> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Jugador")
		{
			Debug.Log("pase por spawn point" + index);
			PadreScript.setChildIndex(index);
		}
	}
}

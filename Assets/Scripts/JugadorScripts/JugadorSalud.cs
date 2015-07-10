using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JugadorSalud : MonoBehaviour, ISalud<int> {
	public int saludInicial = 100;
	public int saludActual;
	public Slider barraDeVida;

	public Image imagenHerida;
	bool herido, muerto;
	public float flashSpeed = 5f;
	public Color colorHerida = new Color(1f, 0f, 0f, 0.1f);
	// Use this for initialization
	void Start () {
		saludActual = saludInicial;
		herido = false;
		muerto = false;
	}

	void Update () {
		if(herido)
		{
			if(saludActual > 0){
				imagenHerida.color = colorHerida;
			}else{
				StartCoroutine (morir ());
			}
		}
		else
		{
			imagenHerida.color = Color.Lerp (imagenHerida.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		herido = false;
	}
	public void recibirDaño(int daño){
		herido = true;
		saludActual -= daño;
		Debug.Log (saludActual);
		barraDeVida.value = saludActual;
	}
	public void curarSalud(int curacion){
		saludActual += curacion;
		barraDeVida.value = saludActual;
	}
	public int getSalud(){
		return saludActual;
	}
	public IEnumerator morir(){
		setMuerto (true);
		yield return new WaitForSeconds (0.167f);
	}
	//para pasarle al respawn manager
	public bool getMuerto(){
		return muerto;
	}
	public void setMuerto(bool m){
		muerto = m;
		if (!m) {
			saludActual = saludInicial;
			barraDeVida.value = saludActual;
		}
	}

}

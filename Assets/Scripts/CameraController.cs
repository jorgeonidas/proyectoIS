using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField] Transform Player;
	private Vector3 movetemp;
	[SerializeField] float velocidad = 5;
	[SerializeField] float xDiferencia;
	[SerializeField] float yDiferencia;

	[SerializeField] float movementThreshold = 5;
	[SerializeField] float movementThresholdHeight = 2;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//siempre nos dara un valor positivo
		if (Player.transform.position.x > transform.position.x || Player.transform.position.x < transform.position.x) {
			xDiferencia = Player.transform.position.x - transform.position.x;
		}

		if (Player.transform.position.y > transform.position.y || Player.transform.position.y < transform.position.y) {
			yDiferencia = Player.transform.position.y - transform.position.y;

		}
		if(Mathf.Abs(xDiferencia) >= movementThreshold || Mathf.Abs(yDiferencia) >= movementThresholdHeight){
			movetemp = Player.transform.position;
			movetemp.z = -10;
			movetemp.y = movetemp.y +2;
			//transform.position = Vector3.MoveTowards(transform.position,movetemp,velocidad * Time.deltaTime );
			transform.position = Vector3.SmoothDamp(transform.position, movetemp, ref velocity, smoothTime);
		}
	}
}

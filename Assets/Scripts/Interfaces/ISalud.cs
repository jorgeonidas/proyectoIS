using UnityEngine;
using System.Collections;

public interface ISalud<T> {

	void recibirDaño(T daño);
	void curarSalud(T curacion);
	IEnumerator morir();

}

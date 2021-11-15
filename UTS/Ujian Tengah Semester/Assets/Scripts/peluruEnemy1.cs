using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluruEnemy1 : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "playerPesawat") {
			Destroy (this.gameObject);
		} else if (col.gameObject.name.Contains ("Batas")) {
			Destroy (this.gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluru : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name.Contains ("Batas")) {
			Destroy (this.gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambilBintang : MonoBehaviour {

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.name == "bintang(Clone)") {
			float step = 2f * Time.deltaTime;
			coll.transform.position = Vector2.MoveTowards (coll.transform.position, transform.position, step);
		} 	
	}
}

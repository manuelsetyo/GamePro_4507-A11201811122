using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotasiPesawatEnemy : MonoBehaviour {

	private Transform target;
	private Transform pesawatEnemy;
	void Start () {
		pesawatEnemy = transform.Find ("enemy").GetComponent <Transform> ();
		target = GameObject.Find ("player").GetComponent <Transform> ();
	}

	void Update () {
		if (target) {
			Vector3 dir = transform.position - target.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			if (pesawatEnemy) {
				pesawatEnemy.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			} else {
				Destroy (this.gameObject);
			}
		}
	}
}

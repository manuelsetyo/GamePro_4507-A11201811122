using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluruEnemy : MonoBehaviour {

	public Rigidbody2D rb;
	public float rotation = 0;
	void Start () {
		this.transform.rotation = Quaternion.AngleAxis (rotation, Vector3.forward);
		rb.velocity = transform.TransformDirection (Vector2.up * 5);
	}
}

using UnityEngine;
using System.Collections;

public class peluruTembak : MonoBehaviour {

	public Rigidbody2D rb;

	void Start () {
		this.transform.rotation = Quaternion.AngleAxis (vars.angle-90, Vector3.forward);
		rb.velocity = transform.TransformDirection (Vector2.up * 12);
		Destroy (this.gameObject, 2f);
	}
	

}

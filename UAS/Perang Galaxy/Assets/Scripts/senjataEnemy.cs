using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class senjataEnemy : MonoBehaviour {

	public GameObject senjata;
	private float timer = 0;
	public float timeTembak = 3f;
	public int tipeEnemy;
	GameObject peluru;

	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeTembak) {
			timer = 0;
			if (tipeEnemy == 1) {
				peluru = Instantiate (Resources.Load ("peluruEnemy1"), new Vector2 (senjata.transform.position.x, senjata.transform.position.y), Quaternion.identity) as GameObject;
			} else {
				peluru = Instantiate (Resources.Load ("peluruEnemy2"), new Vector2 (senjata.transform.position.x, senjata.transform.position.y), Quaternion.identity) as GameObject;
			}
			peluru.GetComponent<peluruEnemy> ().rotation = transform.eulerAngles.z + 90;
		}
	}
}

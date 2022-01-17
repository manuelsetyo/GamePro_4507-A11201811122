using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hancurBintang : MonoBehaviour {

	float scale;
	float timer = 0;
	void Start () {
		scale = transform.localScale.x;
		GameObject.Find("bintangTerambil").GetComponent<AudioSource> ().Play();
	}
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 0.1f) {
			timer = 0;
			scale -= 0.05f;
			transform.localScale = new Vector2 (scale, scale);
			if (scale <= 0) {
				PlayerPrefs.SetInt ("bintangTerambil", PlayerPrefs.GetInt ("bintangTerambil") + 1);
				Destroy (this.gameObject);
			}
		}
	}
}

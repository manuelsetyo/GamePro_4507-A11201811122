using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitEnemy : MonoBehaviour {

	public float darahEnemy = 50;
	private int darahAwal;
	void Start() {
		darahEnemy = darahEnemy * vars.level;
		darahAwal = (int)darahEnemy;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains("peluru")) {
			darahEnemy -= (PlayerPrefs.GetInt("damageLevel") * 10 + 30);
			if (darahEnemy <= 0) {
				GameObject.Find("suaraPeluru").GetComponent <AudioSource> ().Play ();
				vars.skor += darahAwal;
				int number = Random.Range (1, 5);
				for (int i = 0; i < number; i++) {
					Instantiate (Resources.Load ("bintang"), new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				}
				GameObject.Find ("game").transform.Find ("skor").GetComponent<Text> ().text = "SKOR : " + vars.skor;

				if (transform.Find ("skor") != null) {
					GameObject g = transform.Find ("skor").gameObject;
					g.transform.parent = null;
					g.transform.localRotation = Quaternion.Euler(0,0,0);
					g.GetComponent<teksSkor> ().enabled = true;
					g.GetComponent<teksSkor> ().skor = darahAwal;
				}

				if (this.gameObject.transform.parent != null) {
					Destroy (this.gameObject.transform.parent.gameObject);
				}

				Destroy (this.gameObject);
			} else {
				GameObject.Find("suaraBenturan").GetComponent <AudioSource> ().Play ();
				Destroy (col.gameObject);

			}
		}
	}

	public void destroyEnemy() {
		if (this.gameObject.transform.parent != null) {
			Destroy (this.gameObject.transform.parent.gameObject);
		}

		Destroy (this.gameObject);
	}
}

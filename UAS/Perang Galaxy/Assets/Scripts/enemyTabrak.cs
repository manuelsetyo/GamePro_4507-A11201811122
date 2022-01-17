using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyTabrak : MonoBehaviour {

	public float darahPlayer = 100;
	float darahAwal = 0;
	public Text darahPesawat;
	void Start () {
		resetDarah (); 
	}

	void resetDarah() {
		darahPlayer = 100;
		if (GameObject.Find ("darahPlayer") != null) {
			darahPesawat = GameObject.Find ("darahPlayer").GetComponent<Text> ();
			darahPesawat.text = "DARAH : 100%";
		}
		if (PlayerPrefs.GetInt ("levelDarah") > 1) {
			darahPlayer = darahPlayer * (int)((PlayerPrefs.GetInt ("levelDarah") + 1) / 2);
		}
		darahAwal = darahPlayer; 
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("enemy")) {
			if (col.gameObject.name.Contains ("peluruEnemy1")) {
				darahPlayer -= 10 * vars.levelPeluru;
			} else {
				darahPlayer -= (int)col.gameObject.GetComponent <hitEnemy> ().darahEnemy;
				col.gameObject.GetComponent <hitEnemy> ().destroyEnemy ();
			}
			if (darahPlayer <= 0) {
				darahPlayer = 0;
				GameObject.Find ("Canvas").GetComponent <gameover> ().tombolGameOver ();
				Destroy (GameObject.Find ("player"));
			}
			if (darahPesawat != null) {
				darahPesawat.text = "DARAH : " + (int)((darahPlayer / darahAwal) * 100) + "%";
			} else {
				darahPesawat = GameObject.Find ("darahPlayer").GetComponent<Text> ();
				darahPesawat.text = "DARAH : " + (int)((darahPlayer / darahAwal) * 100) + "%";
			}
		} else if (col.gameObject.name.Contains ("asteroid")) {
			darahPlayer -= (int)col.gameObject.GetComponent <hitEnemy> ().darahEnemy;
			col.gameObject.GetComponent <hitEnemy> ().destroyEnemy ();
		
			if (darahPlayer <= 0) {
				darahPlayer = 0;
				GameObject.Find ("Canvas").GetComponent <gameover> ().tombolGameOver ();
				Destroy (GameObject.Find ("player"));
			}
			if (darahPesawat != null) {
				darahPesawat.text = "DARAH : " + (int)((darahPlayer / darahAwal) * 100) + "%";
			} else {
				darahPesawat = GameObject.Find ("darahPlayer").GetComponent<Text> ();
				darahPesawat.text = "DARAH : " + (int)((darahPlayer / darahAwal) * 100) + "%";
			}
		}
	}
	public void kalkulasiDarahPesawat() {
		resetDarah ();
		if (darahPesawat != null) {
			darahPesawat.text = "DARAH : " + (int)((darahPlayer / darahAwal) * 100) + "%";
		}
	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.name == "bintang(Clone)") {
			coll.gameObject.GetComponent<hancurBintang> ().enabled = true;
		}

	}
}

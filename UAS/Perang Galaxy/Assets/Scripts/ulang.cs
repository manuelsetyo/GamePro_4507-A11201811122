using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ulang : MonoBehaviour {

	public void ulangGameOver () {
		
		GameObject.Find ("klikTombol").GetComponent<AudioSource> ().Play ();
		if (GameObject.Find ("game").transform.Find ("skor") != null) {
			GameObject.Find ("game").transform.Find ("skor").GetComponent <Text> ().text = "SKOR : 0";
			GameObject.Find("game").transform.Find ("darahPlayer").GetComponent <Text> ().text = "DARAH : 100%";
		}

		vars.skor = 0;
		GameObject[] enemyz = GameObject.FindGameObjectsWithTag ("enemy");
		for (int i = 0; i < enemyz.Length; i++) {
			Destroy (enemyz [i]);
		}
		GameObject[] peluruz = GameObject.FindGameObjectsWithTag ("peluru");
		for (int i = 0; i < peluruz.Length; i++) {
			Destroy (peluruz [i]);
		}
		GameObject[] bintangz = GameObject.FindGameObjectsWithTag ("bintang");
		for (int i = 0; i < bintangz.Length; i++) {
			Destroy (bintangz [i]);
		}

		GameObject.Find ("Canvas").GetComponent<gameover> ().tombolGameOver ();
		GameObject g = Instantiate (Resources.Load ("player"), new Vector2 (0, 0), Quaternion.identity) as GameObject;
		g.name = "player";
		g.GetComponent<munculEnemy> ().enabled = true;
		GameObject.Find ("camera").GetComponent<cameraFollow> ().targerBaru ();
		vars.level = 1;
		if (GameObject.Find ("playerPesawat") != null) {
			GameObject.Find ("playerPesawat").GetComponent<enemyTabrak> ().kalkulasiDarahPesawat ();
		}
		vars.gameover = false;
	}

	public void ulangPauseGame() {
		vars.gameover = false;
		if (GameObject.Find ("game").transform.Find ("skor") != null) {
			GameObject.Find ("game").transform.Find ("skor").GetComponent <Text> ().text = "SKOR : 0";
		}
		vars.skor = 0;
		GameObject[] enemyz = GameObject.FindGameObjectsWithTag ("enemy");
		for (int i = 0; i < enemyz.Length; i++) {
			Destroy (enemyz [i]);
		}
		GameObject[] peluruz = GameObject.FindGameObjectsWithTag ("peluru");
		for (int i = 0; i < peluruz.Length; i++) {
			Destroy (peluruz [i]);
		}
		GameObject[] bintangz = GameObject.FindGameObjectsWithTag ("bintang");
		for (int i = 0; i < bintangz.Length; i++) {
			Destroy (bintangz [i]);
		}
		if (GameObject.Find ("player") != null) {
			GameObject.Find ("player").transform.position = new Vector2 (0, 0);
		}
		vars.level = 1;
		if (GameObject.Find ("playerPesawat") != null) {
			GameObject.Find ("playerPesawat").GetComponent<enemyTabrak> ().kalkulasiDarahPesawat ();
		}
	}
}

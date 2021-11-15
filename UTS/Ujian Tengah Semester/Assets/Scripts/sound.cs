using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {

	public void cekSound() {
		if (PlayerPrefs.GetInt ("sound") == 0) {
			GameObject.Find ("tembakan").GetComponent<AudioSource> ().volume = 1;
			GameObject.Find ("suaraPeluru").GetComponent<AudioSource> ().volume = 1;
			GameObject.Find ("bintangTerambil").GetComponent<AudioSource> ().volume = 1;
			GameObject.Find ("suaraBenturan").GetComponent<AudioSource> ().volume = 1;
			GameObject.Find ("klikTombol").GetComponent<AudioSource> ().volume = 1;
		} else {
			GameObject.Find ("tembakan").GetComponent<AudioSource> ().volume = 0;
			GameObject.Find ("suaraPeluru").GetComponent<AudioSource> ().volume = 0;
			GameObject.Find ("bintangTerambil").GetComponent<AudioSource> ().volume = 0;
			GameObject.Find ("suaraBenturan").GetComponent<AudioSource> ().volume = 0;
			GameObject.Find ("klikTombol").GetComponent<AudioSource> ().volume = 0;
		}
	}

	public void cekMusik () {
		if (PlayerPrefs.GetInt ("musik") == 0) {
			
		} else {
	
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mulai : MonoBehaviour {

	float timer = 0;
	float fade = 0;
	bool gantiScene = false;
	bool gp = false;
	public GameObject image;
	public GameObject mainMenu;
	public GameObject gameUI;
	Image im;
	float volume = 1;

	void Start () {
		im = image.GetComponent <Image> ();
	}

	void Update () {
		if (gp) {
			timer += Time.deltaTime;
			if (timer >= 0.02f) {
				timer = 0;
				if (gantiScene == false) {
					fade += 0.1f;
					if (fade >= 1.5f) {
						volume = 0;
						mainMenu.SetActive (false);
						gameUI.SetActive (true);
						GameObject.Find("player").GetComponent <munculEnemy> ().enabled = true;
						gantiScene = true;
						if (GameObject.Find ("playerPesawat") != null) {
							GameObject.Find ("playerPesawat").GetComponent<enemyTabrak> ().darahPlayer = 100;
						}
						if (GameObject.Find ("game").transform.Find ("skor") != null) {
							GameObject.Find ("game").transform.Find ("skor").GetComponent <Text> ().text = "SKOR : 0";
						}
					}
				} else {
					
					fade -= 0.1f;
					if (fade <= 0f) {
						if (PlayerPrefs.GetInt ("musik") == 0) {
							volume = 1;
						}
						gp = false;
						fade = 0;
						gantiScene = false;
					}
				}
				if (PlayerPrefs.GetInt ("musik") == 1) {
					volume = 0;
				}
				im.color = new Color (0, 0, 0, fade);
			}
		}
	}

	public void playGame () {
		GameObject.Find ("klikTombol").GetComponent<AudioSource> ().Play ();
		vars.skor = 0;
		GameObject.Find ("camera").GetComponent<cameraFollow> ().targerBaru ();
		gp = true;
		GameObject.Find ("Canvas").GetComponent<sound> ().cekMusik ();
		GameObject.Find ("Canvas").GetComponent<sound> ().cekSound ();
		vars.gameover = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keluarGame : MonoBehaviour {

	float timer = 0;
	float fade = 0;
	bool gantiScene = false;
	bool gp = false;
	public GameObject image;
	public GameObject mainMenu;
	public GameObject gameUI;
	public GameObject player;
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
						GameObject.Find ("Canvas").GetComponent<ulang> ().ulangPauseGame ();
						volume = 0;
						if (GameObject.Find ("darahPlayer") != null) {
							GameObject.Find ("darahPlayer").GetComponent<Text> ().text = "DARAH : 100%";
						}
						mainMenu.SetActive (true);
						gameUI.SetActive (false);
						if (GameObject.Find ("player") != null) {
							GameObject.Find ("player").GetComponent <munculEnemy> ().enabled = false;
						} else {
							GameObject g = Instantiate (Resources.Load ("player"), new Vector2 (0, 0), Quaternion.identity) as GameObject;
							g.name = "player";
						}
						gantiScene = true;
						vars.gameover = true;
					}
				} else {

					fade -= 0.1f;
					if (fade <= 0f) {
						if (PlayerPrefs.GetInt ("musik") == 0) {
							volume = 1;
						}
						GameObject.Find ("Canvas").GetComponent<sound> ().cekMusik ();
						GameObject.Find ("Canvas").GetComponent<sound> ().cekSound ();
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

	public void keluarPauseGame () {
		GameObject.Find ("klikTombol").GetComponent<AudioSource> ().Play ();
		GameObject.Find("Canvas").GetComponent <pause> ().tombolPause ();
		gp = true;
		vars.gameover = true;
	}
	public void keluarGameOver () {
		GameObject.Find ("klikTombol").GetComponent<AudioSource> ().Play ();
		GameObject.Find("Canvas").GetComponent <gameover> ().tombolGameOver ();
		gp = true;
		vars.gameover = true;
	}
}
